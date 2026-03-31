# Create cyberpunk checkbox with neon inner fill
WORKFLOW ==> cyberpunk-checkbox-with-neon-inner-fill

## Visual identity
A pure HTML and CSS minimalist cyberpunk style checkbox with a glowing cyan outline, dark transparent interior, and a small neon filled square that scales into view when checked. The control is paired with a clean white label and feels crisp, futuristic, and lightweight.

## Workflow description
Create a pure HTML and CSS cyberpunk checkbox using a custom input appearance and a scaling neon inner fill effect.

### Required structure
1. Use a label element as the clickable wrapper.
2. Place a checkbox input inside the label.
3. Place plain text inside the label after the checkbox input.
4. Keep the label and checkbox aligned on one line.

### Required styling
1. Remove the native checkbox appearance.
2. Style the checkbox as a compact square around 20px by 20px.
3. Use a transparent background by default.
4. Add a cyan or turquoise border around the checkbox.
5. Use slightly rounded corners around 5px.
6. Display the checkbox inline and keep a small right margin before the label text.
7. Use a pointer cursor on both checkbox and label.
8. Style the label text in white.
9. Use a clean font size around 18px.
10. Disable text selection on the label.
11. Align label contents vertically using flex.

### Required checked state behavior
1. Create the checked indicator using the checkbox before pseudo element.
2. Style the indicator as a smaller filled square centered inside the checkbox.
3. Use the same cyan or turquoise color as the border.
4. Keep the indicator scaled down to zero by default.
5. On checked state, scale the inner square up to full size.
6. Use a smooth transition around 0.3 seconds with ease in out timing.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use appearance none to reset the native checkbox styling.
4. Use the before pseudo element of the checkbox for the animated inner fill.
5. Keep the component suitable for futuristic forms or neon themed interfaces.

### Code fingerprint
```html
<label class="cyberpunk-checkbox-label">
  <input type="checkbox" class="cyberpunk-checkbox">
  Check me
</label>
```

```css
.cyberpunk-checkbox {
  appearance: none;
  width: 20px;
  height: 20px;
  border: 2px solid #30cfd0;
  border-radius: 5px;
  background-color: transparent;
  position: relative;
}

.cyberpunk-checkbox:before {
  content: "";
  background-color: #30cfd0;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%) scale(0);
  width: 10px;
  height: 10px;
  border-radius: 3px;
  transition: all 0.3s ease-in-out;
}

.cyberpunk-checkbox:checked:before {
  transform: translate(-50%, -50%) scale(1);
}
```

### Search keywords
cyberpunk checkbox, neon checkbox, cyan outline checkbox, futuristic form control, inner fill checkbox animation, pure css custom checkbox, sci fi checkbox ui, minimalist neon toggle box
