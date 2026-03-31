# Create neumorphic round checkbox with inset check
WORKFLOW ==> neumorphic-round-checkbox-with-inset-check

## Visual identity
A pure HTML and CSS round neumorphic checkbox with a soft light gray surface, raised outer shadows in the default state, and an inset pressed look when checked. A subtle dark gray checkmark appears inside the circular control, giving it a clean soft UI aesthetic.

## Workflow description
Create a pure HTML and CSS neumorphic circular checkbox using a hidden native checkbox input and a custom round checkmark element.

### Required structure
1. Use a label element as the clickable wrapper.
2. Place a checkbox input inside the label.
3. Hide the native checkbox visually while keeping it functional.
4. Add a separate visual element for the custom circular checkbox.
5. Use sibling selectors so the input checked state controls the custom checkbox appearance.

### Required styling
1. Style the wrapper as a compact clickable element.
2. Use a hidden input with zero visible size and full functionality.
3. Style the custom checkbox as a small circle around 1.3em by 1.3em.
4. Use a soft light gray background.
5. Add raised neumorphic outer shadows in the default state.
6. Use a fully rounded border radius.
7. Use a smooth transition around 0.5 seconds.
8. Keep the component minimal and tactile.

### Required checked state behavior
1. When checked, switch the circular control from raised shadows to inset shadows.
2. Make the control look pressed inward.
3. Reveal a subtle dark gray checkmark inside the circle.
4. Keep the transition smooth and soft.

### Required checkmark behavior
1. Create the checkmark using the after pseudo element of the custom checkbox.
2. Keep the checkmark hidden by default using opacity.
3. Draw the checkmark using borders and rotation.
4. Position the checkmark neatly inside the center area of the circle.
5. On checked state, fade the checkmark in.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the hidden checkbox plus sibling selector pattern.
4. Use the after pseudo element for the checkmark stroke.
5. Keep the component suitable for soft UI forms and settings interfaces.

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
  border-radius: 100%;
  background: #e8e8e8;
  box-shadow: 3px 3px 5px #c5c5c5,
              -3px -3px 5px #ffffff;
  transition-duration: 0.5s;
}

.container input:checked ~ .checkmark {
  box-shadow: inset 3px 3px 5px #c5c5c5,
              inset -3px -3px 5px #ffffff;
}

.container .checkmark:after {
  border: solid darkgray;
  border-width: 0 0.15em 0.15em 0;
  transform: rotate(45deg);
}
```

### Search keywords
neumorphic round checkbox, soft ui checkbox, inset circular checkbox, raised pressed checkbox, minimalist circular checkbox, pure css neumorphic control, soft shadow checkbox, round checkmark toggle
