# Create SVG stroke draw checkbox with label
WORKFLOW ==> svg-stroke-draw-checkbox-with-label

## Visual identity
A pure HTML and CSS custom checkbox built with an SVG square outline and animated tick mark. The box and check stroke are drawn into view when the checkbox is selected, creating a sleek vector animation with a vivid purple accent and a clean label beside it.

## Workflow description
Create a pure HTML and CSS checkbox using a hidden native input, an SVG box outline, and an animated SVG checkmark stroke.

### Required structure
1. Use an outer wrapper element for the checkbox component.
2. Place a checkbox input inside the wrapper.
3. Add a label linked to the input using matching id and for attributes.
4. Inside the label, place an SVG element for the custom checkbox graphic.
5. Inside the SVG, include one rectangular outline shape.
6. Inside the SVG, include one path element for the checkmark.
7. Add a text span beside the SVG for the label text.

### Required styling
1. Hide the native checkbox input.
2. Style the label as a horizontal flex row aligned vertically in the center.
3. Use pointer cursor on the label.
4. Add a small gap between the SVG and the label text.
5. Size the SVG around 30px by 30px.
6. Use a faint neutral fill inside the checkbox box.
7. Use a bright purple stroke for both the outline and the checkmark.
8. Keep the component minimal, clean, and modern.

### Required animation behavior
1. Use stroke dash array and stroke dash offset on the rectangular outline.
2. Keep the outline fully hidden at first by matching the dash offset to the dash array.
3. Use stroke dash array and stroke dash offset on the checkmark path as well.
4. Keep the checkmark hidden at first.
5. On checked state, animate both dash offsets to zero.
6. Use smooth ease in timing around 0.6 seconds.
7. Trigger both SVG animations when the checkbox becomes checked.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the checked plus adjacent sibling selector pattern from the hidden input to the label.
4. Use SVG shapes so the stroke reveal feels precise and crisp.
5. Keep the component suitable for forms, consent checkboxes, and stylish settings UIs.

### Code fingerprint
```html
<div class="checkbox-wrapper">
  <input id="terms-checkbox-37" name="checkbox" type="checkbox">
  <label class="terms-label" for="terms-checkbox-37">
    <svg class="checkbox-svg" viewBox="0 0 200 200">
      <rect class="checkbox-box" height="200" width="200"></rect>
      <path class="checkbox-tick" d="M52 111.018L76.9867 136L149 64"></path>
    </svg>
    <span class="label-text">Checkbox</span>
  </label>
</div>
```

```css
.checkbox-wrapper input[type="checkbox"] {
  display: none;
}

.checkbox-wrapper .terms-label {
  cursor: pointer;
  display: flex;
  align-items: center;
}

.checkbox-wrapper .checkbox-svg {
  width: 30px;
  height: 30px;
}

.checkbox-wrapper .checkbox-box {
  fill: rgba(207, 205, 205, 0.425);
  stroke: #8c00ff;
  stroke-dasharray: 800;
  stroke-dashoffset: 800;
  transition: stroke-dashoffset 0.6s ease-in;
}

.checkbox-wrapper .checkbox-tick {
  stroke: #8c00ff;
  stroke-dasharray: 172;
  stroke-dashoffset: 172;
  transition: stroke-dashoffset 0.6s ease-in;
}

.checkbox-wrapper input[type="checkbox"]:checked + .terms-label .checkbox-box,
.checkbox-wrapper input[type="checkbox"]:checked + .terms-label .checkbox-tick {
  stroke-dashoffset: 0;
}
```

### Search keywords
svg checkbox, stroke draw checkbox, animated tick checkbox, purple outline checkbox, svg checkmark animation, hidden input custom checkbox, pure css svg checkbox, vector checkbox ui
