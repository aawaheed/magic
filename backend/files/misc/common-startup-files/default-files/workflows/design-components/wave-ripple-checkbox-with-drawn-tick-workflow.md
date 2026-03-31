# Create wave ripple checkbox with drawn tick
WORKFLOW ==> wave-ripple-checkbox-with-drawn-tick

## Visual identity
A pure HTML and CSS compact checkbox with a clean bordered square, a soft blue checked state, and an animated white tick that draws itself in. When selected, the checkbox briefly compresses and emits a fading ripple wave from its center, creating a polished modern micro interaction.

## Workflow description
Create a pure HTML and CSS checkbox with a hidden native input, animated checkmark stroke, and a ripple wave effect on check.

### Required structure
1. Use an outer wrapper element for the component.
2. Place a checkbox input inside the wrapper.
3. Add a label linked to the input using matching id and for attributes.
4. Inside the label, add one span for the visual checkbox box.
5. Place an SVG tick icon inside the first span.
6. Add a second span for the label text.
7. Keep the label fully clickable.

### Required styling
1. Hide the native checkbox input from view.
2. Style the label as a compact inline control with pointer cursor.
3. Prevent text selection on the label.
4. Style the checkbox box as a small square around 18px by 18px.
5. Use a small corner radius around 3px.
6. Add a neutral gray border in the default state.
7. On hover, change the border color to a vivid blue.
8. Add a small gap between the box and the text.
9. Keep the text simple and clean.

### Required checked state behavior
1. When checked, fill the box with a vivid blue color.
2. When checked, change the border to the same blue color.
3. Animate the box with a brief scale down wave effect.
4. Use an SVG polyline for the white tick mark.
5. Hide the tick initially using stroke dash array and stroke dash offset.
6. On checked state, animate the tick so the stroke draws in.

### Required ripple behavior
1. Create a pseudo element inside the checkbox box for the ripple effect.
2. Start the ripple as a full size shape scaled down.
3. On checked state, expand the ripple outward significantly.
4. Fade the ripple to transparent as it expands.
5. Keep the ripple smooth and slightly delayed relative to the box fill.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the checked plus adjacent sibling selector pattern.
4. Use SVG for the tick stroke animation.
5. Use a pseudo element for the ripple wave.
6. Keep the component suitable for clean modern forms and preference toggles.

### Code fingerprint
```html
<div class="checkbox-wrapper-46">
  <input type="checkbox" id="cbx-46" class="inp-cbx" />
  <label for="cbx-46" class="cbx">
    <span>
      <svg viewBox="0 0 12 10" height="10px" width="12px">
        <polyline points="1.5 6 4.5 9 10.5 1"></polyline>
      </svg>
    </span>
    <span>Checkbox</span>
  </label>
</div>
```

```css
.checkbox-wrapper-46 input[type="checkbox"] {
  display: none;
  visibility: hidden;
}

.checkbox-wrapper-46 .cbx span:first-child {
  width: 18px;
  height: 18px;
  border-radius: 3px;
  border: 1px solid #9098a9;
}

.checkbox-wrapper-46 .cbx span:first-child svg {
  stroke: #ffffff;
  stroke-dasharray: 16px;
  stroke-dashoffset: 16px;
}

.checkbox-wrapper-46 .inp-cbx:checked + .cbx span:first-child {
  background: #506eec;
  border-color: #506eec;
  animation: wave-46 0.4s ease;
}

.checkbox-wrapper-46 .inp-cbx:checked + .cbx span:first-child svg {
  stroke-dashoffset: 0;
}
```

### Search keywords
wave checkbox, ripple checkbox, drawn tick checkbox, blue animated checkbox, svg tick checkbox, modern form checkbox, pure css ripple checkmark, compact checkbox interaction
