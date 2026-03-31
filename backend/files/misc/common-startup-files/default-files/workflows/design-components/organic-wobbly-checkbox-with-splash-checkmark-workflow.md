# Create organic wobbly checkbox with splash checkmark
WORKFLOW ==> organic-wobbly-checkbox-with-splash-checkmark

## Visual identity
A pure HTML and CSS custom checkbox with an irregular hand drawn blob shape, thick dark outline, cream background, and chunky offset shadow. On hover it tilts and scales slightly, and when checked it flips into an inverted organic shape with a vivid orange fill. The checkmark pops in with a playful splash animation, making the control feel tactile, cartoonish, and energetic.

## Workflow description
Create a pure HTML and CSS organic style checkbox with a blob shaped box, chunky shadow, animated checkmark, and playful pressed interaction.

### Required structure
1. Use a label element as the clickable wrapper.
2. Place a checkbox input inside the label.
3. Hide the native checkbox visually.
4. Add a separate element for the custom checkbox face.
5. Use sibling selectors so the input checked state controls the visual checkbox element.

### Required styling
1. Style the wrapper as a compact square clickable area around 1.5em by 1.5em.
2. Use a large enough font size around 25px so the control scales nicely.
3. Style the custom checkbox with a light cream background.
4. Add a thick dark border around the checkbox.
5. Use an irregular asymmetric border radius to create an organic blob shape.
6. Add a chunky dark offset box shadow for a cutout comic style look.
7. Use smooth transitions on transform and box shadow.

### Required hover behavior
1. On hover, slightly scale the checkbox up.
2. On hover, rotate it slightly.
3. Keep the hover effect playful and subtle.

### Required checked state behavior
1. When checked, change the background to a vivid orange tone.
2. When checked, switch to a different irregular border radius pattern so the shape appears to morph.
3. When checked, slightly scale the checkbox larger.
4. When checked, rotate it slightly in the opposite direction.

### Required checkmark behavior
1. Create the checkmark using the after pseudo element of the custom checkbox.
2. Hide the checkmark by default.
3. Draw it using thick dark borders rotated diagonally.
4. When checked, show the checkmark.
5. Animate the checkmark with a short splash or pop in effect.
6. Start the checkmark from scale zero and opacity zero.
7. Overshoot slightly before settling at normal size.

### Required active press behavior
1. On active press, scale the checkbox down slightly.
2. Move it downward a little to simulate pressing.
3. Remove or flatten the box shadow during the active state.
4. Keep the pressed effect quick and tactile.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use a hidden checkbox plus sibling selector pattern.
4. Use an irregular border radius for the blob shape.
5. Use the after pseudo element for the animated checkmark.
6. Keep the component fun, handmade, and expressive.

### Code fingerprint
```html
<label class="container">
  <input type="checkbox" checked="checked" />
  <div class="checkmark"></div>
</label>
```

```css
.container {
  position: relative;
  width: 1.5em;
  height: 1.5em;
}

.container .checkmark {
  height: 1.5em;
  width: 1.5em;
  background-color: #fdfcf0;
  border: 4px solid #1a1a1a;
  border-radius: 8% 92% 12% 88% / 87% 11% 89% 13%;
  box-shadow: 5px 5px 0 #1a1a1a;
}

.container input:checked ~ .checkmark {
  background-color: #ff5722;
  border-radius: 92% 8% 88% 12% / 11% 87% 13% 89%;
}

.container input:checked ~ .checkmark:after {
  display: block;
  animation: splash 0.3s forwards;
}
```

### Search keywords
organic checkbox, blob checkbox, wobbly custom checkbox, playful splash checkmark, cartoon checkbox ui, irregular shape checkbox, handmade css checkbox, orange blob checkmark control
