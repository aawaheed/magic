/*
 * Copyright (c) 2023 Thomas Hansen - For license inquiries you can contact thomas@ainiro.io.
 */

/**
 * Reusable directive dynamically exchanging placeholder of component.
 */
import { Directive, ElementRef, Input, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { fromEvent, Subscription } from 'rxjs';

@Directive({
  selector: '[appTypewriterPlaceholder]'
})
export class TypewriterPlaceholderDirective implements OnInit, OnDestroy {

  // List of phrases to cycle
  @Input('appTypewriterPlaceholder') phrases: string[] = [];

  // Speeds (ms per character)
  @Input() typingSpeed = 70;
  @Input() deletingSpeed = 40;

  // Pauses (ms)
  @Input() pauseAtEnd = 1200;   // after finishing a phrase
  @Input() pauseAtStart = 500;  // before starting the first phrase

  // Behavior
  @Input() loop = true;
  @Input() pauseOnFocus = true; // stop animating while user focuses the field

  private sub = new Subscription();
  private timerId: any = null;

  private phraseIndex = 0;
  private charIndex = 0;
  private deleting = false;
  private running = false;

  // ADDED: remember if we've permanently stopped
  private permanentlyStopped = false;

  constructor(
    private el: ElementRef<HTMLTextAreaElement>,
    private renderer: Renderer2) {}

  ngOnInit(): void {

    // React to user typing — if there's value, don't show placeholder animation
    const input$ = fromEvent<InputEvent>(this.el.nativeElement, 'input');
    this.sub.add(input$.subscribe(() => this.syncWithValue()));

    // Pause/resume on focus/blur if desired
    const focus$ = fromEvent(this.el.nativeElement, 'focus');
    const blur$  = fromEvent(this.el.nativeElement, 'blur');

    if (this.pauseOnFocus) {
      this.sub.add(focus$.subscribe(() => this.stop()));
      this.sub.add(blur$.subscribe(() => this.maybeStart()));
    }

    // Initial start
    this.maybeStart(true);
  }

  ngOnDestroy(): void {
    this.stop();
    this.sub.unsubscribe();
  }

  private syncWithValue() {
    const hasValue = (this.el.nativeElement.value ?? '').length > 0;
    if (hasValue) {
      this.stop();
      this.setPlaceholder('');
    } else {
      this.maybeStart();
    }
  }

  private maybeStart(initial = false) {
    if (this.running) return;
    if (this.permanentlyStopped) return; // ADDED: don't restart after permanent stop
    if ((this.el.nativeElement.value ?? '').length > 0) return;
    if (!this.phrases || this.phrases.length === 0) return;

    this.running = true;
    const delay = initial ? this.pauseAtStart : 0;
    this.queueTick(delay);
  }

  // UPDATED: support "permanent" stop
  public stop(permanent = false) {
    this.running = false;
    if (permanent) this.permanentlyStopped = true;
    if (this.timerId !== null) {
      clearTimeout(this.timerId);
      this.timerId = null;
    }
  }

  // ADDED: external API to set a static placeholder and permanently stop
  public setStaticPlaceholder(text: string) {
    this.stop(true);
    this.setPlaceholder(text);
  }

  private queueTick(delay: number) {
    this.timerId = setTimeout(() => this.tick(), delay);
  }

  private tick() {
    if (!this.running) return;

    const phrase = this.phrases[this.phraseIndex] ?? '';
    let nextDelay = this.typingSpeed;

    if (!this.deleting) {
      // typing forward
      this.charIndex = Math.min(this.charIndex + 1, phrase.length);
      this.setPlaceholder(phrase.slice(0, this.charIndex));

      if (this.charIndex === phrase.length) {
        // reached end of phrase
        this.deleting = true;
        nextDelay = this.pauseAtEnd;
      }
    } else {
      // deleting backward
      this.charIndex = Math.max(this.charIndex - 1, 0);
      this.setPlaceholder(phrase.slice(0, this.charIndex));
      nextDelay = this.deletingSpeed;

      if (this.charIndex === 0) {
        this.deleting = false;
        this.phraseIndex++;

        if (this.phraseIndex >= this.phrases.length) {
          if (this.loop) {
            this.phraseIndex = 0;
          } else {
            this.stop();
            return;
          }
        }
      }
    }

    this.queueTick(nextDelay);
  }

  private setPlaceholder(text: string) {
    this.renderer.setAttribute(this.el.nativeElement, 'placeholder', text);
  }
}
