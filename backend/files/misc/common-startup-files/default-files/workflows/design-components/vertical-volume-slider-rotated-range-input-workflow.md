# Create vertical volume slider with rotated range input and speaker icon
WORKFLOW ==> vertical-volume-slider-rotated-range-input

## Visual identity
A pure HTML and CSS audio style volume control built from a native range input rotated vertically inside a label container, paired with a speaker icon. The slider has a dark rounded rectangular track and a white fill level created through range thumb shadow styling, giving it a clean minimal media control appearance.

## Workflow description
Create a pure HTML and CSS vertical volume slider using a rotated range input and an inline speaker icon.

### Required structure
1. Use a wrapping label element as the outer slider container.
2. Place an input of type range inside the container.
3. Add an SVG speaker or volume icon inside the same container.
4. Give the range input a class for slider styling.
5. Give the icon a class for independent positioning and sizing.

### Required styling
1. Define reusable CSS variables for:
   - slider width
   - slider height
   - slider background color
   - slider border radius
   - fill color
   - transition duration
   - icon margin
   - icon color
   - icon size
2. Style the outer container as an inline flex element.
3. Use reversed horizontal layout so the icon and rotated slider align cleanly.
4. Vertically center the content.
5. Make the whole component appear clickable with pointer cursor.
6. Style the slider track as a dark rounded rectangle.
7. Make the slider about full width with height around 50px.
8. Use a border radius around 9px.
9. Remove default browser appearance from the range input.
10. Hide overflow on the range track.

### Required slider behavior
1. Rotate the range input by about 270 degrees to create a vertical slider.
2. Use the slider thumb shadow trick to create the visible filled level.
3. Make the thumb itself effectively invisible by setting its width and height to zero.
4. Use a large negative horizontal box shadow on the thumb to fill the track with white or light color.
5. Support both webkit and moz thumb styling.
6. Keep transition timing short and responsive, around 0.1 seconds.

### Required icon behavior
1. Position the speaker icon absolutely within the container.
2. Place it near the left side.
3. Size it around 25px.
4. Use the same dark color as the slider track for the icon.
5. Disable pointer events on the icon so dragging the slider is not interrupted.

### Code fingerprint
```html
<label class="slider">
  <input type="range" class="level" />
  <svg class="volume"></svg>
</label>
```

```css
.slider .level {
  appearance: none;
  transform: rotate(270deg);
  background: rgb(82, 82, 82);
  border-radius: 9px;
  overflow: hidden;
}

.slider .level:-webkit-slider-thumb {
  width: 0;
  height: 0;
  box-shadow: -200px 0 0 200px #fff;
}

.slider .level:-moz-range-thumb {
  width: 0;
  height: 0;
  border: none;
  box-shadow: -200px 0 0 200px #fff;
}

.slider .volume {
  position: absolute;
  left: 0;
  pointer-events: none;
}
```

### Search keywords
vertical volume slider, rotated range input, css audio slider, speaker icon slider, white fill range slider, dark rounded volume control, custom range input vertical, minimal media control slider
