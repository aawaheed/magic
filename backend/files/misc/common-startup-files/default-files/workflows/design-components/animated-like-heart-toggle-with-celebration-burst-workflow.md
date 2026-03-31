# Create animated like heart toggle with celebration burst
WORKFLOW ==> animated-like-heart-toggle-with-celebration-burst

## Visual identity
A pure HTML and CSS like button built as a heart toggle with a soft pink theme. The control shows an outlined heart by default, then switches to a filled heart when checked. At the same moment, a celebratory burst appears around it, and the filled heart pops into place with a brightened pulse animation.

## Workflow description
Create a pure HTML and CSS heart like toggle using a hidden checkbox, outlined and filled SVG hearts, and a celebratory burst animation.

### Required structure
1. Use an outer wrapper element for the heart control.
2. Place a checkbox input inside the wrapper.
3. Add a container element for the SVG graphics.
4. Include one SVG for the outlined heart state.
5. Include one SVG for the filled heart state.
6. Include one SVG for the celebration burst effect.
7. Keep the checkbox layered above the graphics so the whole heart is clickable.

### Required styling
1. Define a CSS variable for the heart color using a pink tone.
2. Style the outer wrapper as a compact square around 50px by 50px.
3. Position the wrapper relatively.
4. Keep the checkbox invisible but fully clickable across the control.
5. Center all SVG elements inside the wrapper.
6. Use the same heart color for both the outline and the filled heart.
7. Layer the SVG elements absolutely so they overlap.
8. Keep transitions and animations smooth and playful.

### Required checked state behavior
1. Show the outlined heart by default.
2. Hide the filled heart by default.
3. Hide the celebration burst by default.
4. When checked, display the filled heart.
5. When checked, display the celebration burst.
6. Keep the outlined heart visible underneath or alongside the filled state if desired.

### Required animation behavior
1. Animate the filled heart with a pop in effect.
2. Start the filled heart scaled down to zero.
3. Overshoot slightly above full size.
4. Settle at normal scale.
5. Briefly increase brightness during the animation.
6. Animate the celebration burst separately.
7. Start the burst scaled down.
8. Expand the burst outward while fading it away.
9. Keep the burst short around 0.5 seconds.
10. Keep the filled heart animation around 1 second.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use a hidden checkbox with sibling selectors to control the visible SVG states.
4. Use separate SVGs for outlined heart, filled heart, and celebration burst.
5. Keep the component suitable for like, favorite, or save interactions.

### Code fingerprint
```html
<div class="heart-container" title="Like">
  <input type="checkbox" class="checkbox" id="Give-It-An-Id">
  <div class="svg-container">
    <svg class="svg-outline"></svg>
    <svg class="svg-filled"></svg>
    <svg class="svg-celebrate"></svg>
  </div>
</div>
```

```css
.heart-container {
  --heart-color: rgb(255, 91, 137);
  position: relative;
  width: 50px;
  height: 50px;
}

.heart-container .checkbox:checked ~ .svg-container .svg-filled {
  display: block;
}

.heart-container .checkbox:checked ~ .svg-container .svg-celebrate {
  display: block;
}

@keyframes keyframes-svg-filled {
  0% {
    transform: scale(0);
  }
  25% {
    transform: scale(1.2);
  }
  50% {
    transform: scale(1);
    filter: brightness(1.5);
  }
}

@keyframes keyframes-svg-celebrate {
  0% {
    transform: scale(0);
  }
  100% {
    transform: scale(1.4);
    opacity: 0;
  }
}
```

### Search keywords
heart like toggle, animated heart checkbox, favorite button with burst, pink heart animation, svg heart fill effect, celebration burst like button, pure css like control, heart pop animation
