# Create gradient checkmark checkbox with soft shadow
WORKFLOW ==> gradient-checkmark-checkbox-with-soft-shadow

## Visual identity
A pure HTML and CSS custom checkbox with a soft gray square base, rounded corners, and subtle offset shadow. When checked, it switches to a purple pink gradient background, deepens its shadow slightly, and reveals a clean white checkmark. The component feels compact, playful, and polished.

## Workflow description
Create a pure HTML and CSS custom checkbox using a hidden native checkbox input and a styled square checkmark element.

### Required structure
1. Use a label element as the clickable wrapper.
2. Place a checkbox input inside the label.
3. Hide the native checkbox visually while keeping it functional.
4. Add a separate visual element for the custom checkbox square.
5. Use sibling selectors so the input checked state controls the custom checkbox appearance.

### Required styling
1. Style the wrapper as a compact clickable element.
2. Use a hidden input with zero visible size and full functionality.
3. Style the custom checkbox as a small rounded square around 1.3em by 1.3em.
4. Use a light gray default background.
5. Add a subtle offset gray box shadow in the default state.
6. Use smooth transitions around 0.2 seconds.
7. Keep the component visually simple and tactile.

### Required checked state behavior
1. When checked, change the square background to a diagonal purple to pink gradient.
2. Increase or shift the gray box shadow slightly to emphasize the active state.
3. Keep the checked state transition smooth.
4. Reveal a white checkmark inside the square.

### Required checkmark behavior
1. Create the checkmark using the after pseudo element of the custom square.
2. Keep the checkmark hidden by default using opacity.
3. On checked state, fade the checkmark in.
4. Draw the checkmark using white borders and rotation.
5. Position the checkmark neatly in the center area of the square.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the hidden checkbox plus sibling selector pattern.
4. Use the after pseudo element for the checkmark stroke.
5. Keep the component suitable for forms, option lists, and compact settings interfaces.

### Code fingerprint
```html
<label class="container">
  <input type="checkbox" checked="checked">
  <div class="checkmark"></div>
</label>
```

```css
.container input {
  position: absolute;
  opacity: 0;
  height: 0;
  width: 0;
}

.checkmark {
  height: 1.3em;
  width: 1.3em;
  background-color: #ccc;
  border-radius: 5px;
}

.container input:checked ~ .checkmark {
  background-image: linear-gradient(45deg, rgb(100, 61, 219) 0%, rgb(217, 21, 239) 100%);
}

.checkmark:after {
  content: "";
  position: absolute;
  opacity: 0;
}

.container input:checked ~ .checkmark:after {
  opacity: 1;
}
```

### Search keywords
gradient checkbox, custom checkmark box, purple pink checkbox, rounded checkbox ui, hidden input custom checkbox, soft shadow checkbox, pure css checkbox, small gradient form control
