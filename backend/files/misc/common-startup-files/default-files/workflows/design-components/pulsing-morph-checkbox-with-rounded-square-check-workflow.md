# Create pulsing morph checkbox with rounded square check
WORKFLOW ==> pulsing-morph-checkbox-with-rounded-square-check

## Visual identity
A pure HTML and CSS custom checkbox that starts as a soft gray circle and transforms into a deep green rounded square when checked. The active state includes a playful pulse animation with a rotating wobble and expanding glow ring, while a light checkmark appears inside the shape.

## Workflow description
Create a pure HTML and CSS morphing checkbox using a hidden native checkbox input, a circular custom control, and a pulsing checked animation.

### Required structure
1. Use a label element as the clickable wrapper.
2. Place a checkbox input inside the label.
3. Hide the native checkbox visually while keeping it functional.
4. Add a separate visual element for the custom checkbox shape.
5. Use sibling selectors so the input checked state controls the custom checkbox appearance.

### Required styling
1. Style the wrapper as a compact clickable element.
2. Use a hidden input with zero visible size and full functionality.
3. Style the custom checkbox as a small circle around 1.3em by 1.3em.
4. Use a neutral gray background in the default state.
5. Define a reusable accent color variable using a rich green tone.
6. Use smooth transitions around 300ms.
7. Keep the component simple, modern, and tactile.

### Required checked state behavior
1. When checked, change the background color to the green accent.
2. Morph the shape from a full circle into a rounded square.
3. Trigger a pulse style animation when the checked state appears.
4. Include a slight wobble or rotation during the pulse.
5. Add an expanding glow ring using box shadow during the pulse animation.
6. Settle back to a stable resting state at the end of the animation.

### Required checkmark behavior
1. Create the checkmark using the after pseudo element of the custom checkbox.
2. Keep the checkmark hidden by default.
3. Show the checkmark only when checked.
4. Draw the checkmark using a light border stroke and a 45 degree rotation.
5. Position the checkmark neatly near the center of the shape.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the hidden checkbox plus sibling selector pattern.
4. Use the after pseudo element for the checkmark stroke.
5. Use keyframes for the pulse animation.
6. Keep the component suitable for forms, settings, and success state toggles.

### Code fingerprint
```html
<label class="container">
  <input checked="checked" type="checkbox">
  <div class="checkmark"></div>
</label>
```

```css
.checkmark {
  --clr: #0B6E4F;
  height: 1.3em;
  width: 1.3em;
  background-color: #ccc;
  border-radius: 50%;
  transition: 300ms;
}

.container input:checked ~ .checkmark {
  background-color: var(--clr);
  border-radius: .5rem;
  animation: pulse 500ms ease-in-out;
}

.container .checkmark:after {
  border: solid #E0E0E2;
  border-width: 0 0.15em 0.15em 0;
  transform: rotate(45deg);
}

@keyframes pulse {
  0% {
    box-shadow: 0 0 0 #0B6E4F90;
    rotate: 20deg;
  }
  50% {
    rotate: -20deg;
  }
  100% {
    box-shadow: 0 0 0 13px #0B6E4F30;
    rotate: 0;
  }
}
```

### Search keywords
pulse checkbox, morphing checkbox, green rounded square checkbox, animated custom checkbox, glowing checkbox pulse, wobble checkbox, hidden input checkbox ui, pure css success checkbox
