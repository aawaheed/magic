
/*
 * Copyright (c) 2023 Thomas Hansen - For license inquiries you can contact thomas@ainiro.io.
 */

// Angular and system imports.
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';

// Application specific imports.
import { OpenAIService } from 'src/app/services/openai.service';
import { GeneralService } from 'src/app/services/general.service';
import { MachineLearningEditTrainingSnippetComponent } from '../machine-learning-edit-training-snippet/machine-learning-edit-training-snippet.component';
import { MachineLearningTrainingService } from 'src/app/services/machine-learning-training.service';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs';

/**
 * Helper component to add a widget to a machine learning type.
 */
@Component({
  selector: 'app-machine-learning-add-widget.component',
  templateUrl: './machine-learning-add-widget.component.html',
  styleUrls: ['./machine-learning-add-widget.component.scss']
})
export class MachineLearningAddWidget implements OnInit {

  private hasChanges: boolean = false;
  functions: any[] = [];
  showAllFunctions: boolean = true;
  filterControl: FormControl;
  filterValue: '';

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private openAiService: OpenAIService,
    private generalService: GeneralService,
    private dialogRef: MatDialogRef<MachineLearningAddWidget>,
    private machineLearningTrainingService: MachineLearningTrainingService) { }

  ngOnInit() {

    this.dialogRef.keydownEvents().subscribe(event => {
      if (event.key === "Escape") {
        this.close();
      }
    });

    this.dialogRef.backdropClick().subscribe(event => {
      this.close();
    });

    // Retrieving available functions from backend.
    this.getWidgets();

    // Creating our form control.
    this.filterControl = new FormControl('');
    this.filterControl.valueChanges
      .pipe(debounceTime(400), distinctUntilChanged())
      .subscribe(() => {
        this.filterValue = this.filterControl.value.toLowerCase();
      });
  }

  /*
   * Allows user to view a training snippet generated for the specified function.
   */
  install(el: any) {

    let completion = 'If the user asks you to perform an action associated with this function, then responds with the following in the same message:\n';
    completion += `
___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/render-html-widget.hl]:
{
  "filename":"/modules/tissot-checkout/widgets/tissot-checkout.html"
}
___`;

    if (this.data.systemInstruction) {

      this.dialogRef.close({
        prompt: 'WRITE YOUR PROMPT HERE',
        completion,
      });

    } else {

      // Opening "create new training snippet" dialogue.
      this.dialog.open(MachineLearningEditTrainingSnippetComponent, {
        width: '90vw',
        maxWidth: '1280px',
        data: {
          type: this.data.type,
          initialPrompt: 'WRITE YOUR PROMPT HERE',
          initialCompletion: completion,
          meta: 'FUNCTION_INVOCATION ==> /misc/workflows/workflows/machine-learning/render-html-widget.hl',
        }
      })
      .afterClosed()
      .subscribe((result: any) => {

        if (result) {

          this.generalService.showLoading();
          this.machineLearningTrainingService.ml_training_snippets_create(result).subscribe({
            next: () => {

              this.generalService.hideLoading();
              this.generalService.showFeedback('Snippet successfully created', 'successMessage');
              this.hasChanges = true;
            },
            error: (error: any) => {

              this.generalService.hideLoading();
              this.generalService.showFeedback(error?.error?.message ?? 'Something went wrong as we tried to create your snippet', 'errorMessage', 'Ok', 10000);
            }
          });
        }
      });
    }
  }

  /*
   * Invoked when dialogue is closed by clicking button.
   */
  close() {

    if (this.hasChanges) {

      // Signaling parent that we've got changes.
      this.dialogRef.close({changes: true});

    } else {

      // No changes, signaling parent we don't need to reload snippets.
      this.dialogRef.close();
    }
  }

  getFullDescription(el: any) {

    return el.description + '\n\n' + el.file;
  }

  getCount() {

    if (!this.filterValue || this.filterValue === '') {
      return this.functions.length;
    }
    return this.functions.filter(x => x.file.toLowerCase().includes(this.filterValue) || x.name.toLowerCase().includes(this.filterValue) || x.description.toLowerCase().includes(this.filterValue)).length;
  }

  getFilteredFunctions() {

    if (!this.filterValue || this.filterValue === '') {
      return this.functions;
    }
    return this.functions.filter(x => x.file.toLowerCase().includes(this.filterValue) || x.name.toLowerCase().includes(this.filterValue) || x.description.toLowerCase().includes(this.filterValue));
  }

  removeSearchTerm() {

    this.filterControl.setValue('');
  }

  /*
   * Private helper methods.
   */

  private getWidgets() {

    // Invoking backend to get functions.
    this.generalService.showLoading();
    this.openAiService.getAvailableWidgets(this.showAllFunctions).subscribe({

      next: (result: any[]) => {

        result = result ?? [];
        this.functions = result;
        this.generalService.hideLoading();
      },

      error: () => {

        this.generalService.hideLoading();
        this.generalService.showFeedback('Could not retrieve functions from backend', 'errorMessage');
      }
    });
  }
}
