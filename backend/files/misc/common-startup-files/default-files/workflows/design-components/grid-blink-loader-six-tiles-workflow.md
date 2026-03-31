# Create grid blink loader with six animated tiles
WORKFLOW ==> grid-blink-loader-six-tiles

## Visual identity
A pure HTML and CSS loader made from six square tiles arranged in a compact grid. Each tile pulses in sequence by changing opacity and scale, with a slight rotation at the dimmest state. The result looks like a minimalist dashboard loading indicator or staggered matrix blink animation.

## Workflow description
Create a pure HTML and CSS loading indicator using a small grid of square tiles with staggered blink and scale animation.

### Required structure
1. Use an outer loader container.
2. Place six child span elements inside the container.
3. Arrange the spans in a multi column grid layout.
4. Keep the markup minimal and repetitive.

### Required styling
1. Define reusable CSS variables for the tile color and overall loader size.
2. Style the loader as a CSS grid.
3. Use three equal columns.
4. Use a small gap between tiles around 5px.
5. Set the overall loader size around 70px by 70px.
6. Make each tile fill its grid cell fully.
7. Use a soft gray or muted neutral fill color for the tiles.

### Required animation behavior
1. Animate each tile with a repeating blink effect.
2. At the low point of the animation, reduce opacity to around 0.3.
3. At the low point, also scale the tile down to around 0.5 and add a slight rotation.
4. At the high point, restore full opacity and full scale.
5. Use a short duration around 0.6 seconds.
6. Use alternate infinite linear animation.
7. Stagger each tile animation using nth child delays.
8. Use increasing delays across the tiles to create a traveling pulse through the grid.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use CSS grid for layout.
4. Use nth child selectors to apply staggered delays.
5. Keep the loader minimal and geometric.

### Code fingerprint
```html
<div class="loader">
  <span></span>
  <span></span>
  <span></span>
  <span></span>
  <span></span>
  <span></span>
</div>
```

```css
.loader {
  --color: #a5a5b0;
  --size: 70px;
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 5px;
}

.loader span {
  background-color: var(--color);
  animation: keyframes-blink 0.6s alternate infinite linear;
}

.loader span:nth-child(2) {
  animation-delay: 200ms;
}

.loader span:nth-child(3) {
  animation-delay: 300ms;
}

@keyframes keyframes-blink {
  0% {
    opacity: 0.3;
    transform: scale(0.5) rotate(5deg);
  }
  50% {
    opacity: 1;
    transform: scale(1);
  }
}
```

### Search keywords
grid blink loader, six tile loader, css grid loading animation, blinking square loader, staggered tile pulse loader, matrix loading indicator, geometric tile spinner, pure css grid loader
