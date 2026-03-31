# Create animated loading wave with staggered bars
WORKFLOW ==> animated-loading-wave-staggered-bars

## Visual identity
A pure HTML and CSS loading indicator made from several small vertical rounded bars aligned along the bottom edge. Each bar grows taller and then shrinks in sequence, creating a smooth wave or equalizer style loading animation.

## Workflow description
Create a pure HTML and CSS loading animation using multiple vertical bars with staggered height animation.

### Required structure
1. Use an outer container element for the loader.
2. Place multiple child bar elements inside the container.
3. Use at least four bars.
4. Keep all bars visually aligned along the bottom edge of the container.

### Required styling
1. Style the outer loader container as a horizontal flex layout.
2. Center the bars horizontally.
3. Align the bars to the bottom using flex end alignment.
4. Use a container size around 300px wide and 100px high.
5. Style each bar as a narrow rounded rectangle.
6. Make each bar about 20px wide with a small default height around 10px.
7. Add small horizontal spacing between bars.
8. Use a bright blue fill color or similar accent.
9. Give each bar rounded corners around 5px.

### Required animation behavior
1. Create a keyframes animation that changes bar height over time.
2. Start each bar at a short height.
3. Increase each bar to a taller height near the middle of the animation.
4. Return each bar to its original short height at the end.
5. Use a smooth ease in out infinite animation loop.
6. Set the overall animation duration to around 1 second.
7. Apply staggered animation delays to successive bars so the height changes ripple from one bar to the next.
8. Use delays around 0.1 seconds apart.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use nth child selectors to stagger the animation delays.
4. Keep the visual effect minimal, clean, and suitable as a loading indicator.

### Code fingerprint
```html
<div class="loading-wave">
  <div class="loading-bar"></div>
  <div class="loading-bar"></div>
  <div class="loading-bar"></div>
  <div class="loading-bar"></div>
</div>
```

```css
.loading-wave {
  display: flex;
  justify-content: center;
  align-items: flex-end;
}

.loading-bar {
  width: 20px;
  height: 10px;
  border-radius: 5px;
  animation: loading-wave-animation 1s ease-in-out infinite;
}

.loading-bar:nth-child(2) {
  animation-delay: 0.1s;
}

.loading-bar:nth-child(3) {
  animation-delay: 0.2s;
}

.loading-bar:nth-child(4) {
  animation-delay: 0.3s;
}

@keyframes loading-wave-animation {
  0% {
    height: 10px;
  }
  50% {
    height: 50px;
  }
  100% {
    height: 10px;
  }
}
```

### Search keywords
loading wave, equalizer loader, staggered bar loader, animated loading bars, bouncing height loader, css wave loading animation, four bar loading indicator, pure css loading wave
