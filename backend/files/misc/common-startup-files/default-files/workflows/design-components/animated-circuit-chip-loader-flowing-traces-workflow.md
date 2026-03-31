# Create animated circuit chip loader with flowing traces
WORKFLOW ==> animated-circuit-chip-loader-flowing-traces

## Visual identity
A pure HTML and CSS and SVG loader styled like a futuristic microchip or processor in the center of a circuit board. Colored signal traces animate inward from both sides toward the chip, while the chip has a dark metallic body, pin details, gradient shading, and centered loading text. The overall effect looks like electrical data streaming through a motherboard into a processor.

## Workflow description
Create a pure HTML and CSS and SVG loader showing a central chip with animated glowing circuit traces flowing toward it.

### Required structure
1. Use a main container that centers the loader both horizontally and vertically.
2. Place an SVG inside the loader container.
3. Inside the SVG, define gradient resources for the chip body, chip text, and pins.
4. Create multiple background trace paths on the left and right sides leading toward the chip.
5. Duplicate each trace with a second animated colored path above it.
6. Add a central rounded rectangle chip body.
7. Add small rectangular pin elements on both sides of the chip.
8. Add centered loading text inside the chip.
9. Add small circular endpoint nodes at the outer ends of the traces.

### Required styling
1. Style the outer layout as a centered full size flex container.
2. Keep the loader width responsive and allow the SVG to scale.
3. Style the static trace paths in dark gray.
4. Style the animated trace paths with bright neon colors such as yellow, blue, green, purple, and red.
5. Use drop shadow glow on the animated trace paths based on currentColor.
6. Use a dark metallic gradient for the chip body.
7. Use a light to dark metallic gradient for the text.
8. Use a metallic horizontal gradient for the pins.
9. Add subtle shadow or glow to the chip body for depth.

### Required animation behavior
1. Animate the colored trace paths using stroke dash array and stroke dash offset.
2. Start the animated stroke segment offset so it appears to travel along the full path.
3. Animate the offset toward zero to simulate energy or data flowing into the chip.
4. Use a smooth infinite loop around 3 seconds.
5. Use a cubic bezier timing function similar to cubic-bezier(0.5, 0, 0.9, 1).
6. Keep the motion synchronized but allow multiple colored traces to run at once.

### Required chip details
1. Place the chip approximately in the center of the SVG.
2. Use rounded corners on the chip body.
3. Add multiple short pin rectangles on both left and right edges.
4. Add the word Loading centered inside the chip.
5. Use a dark industrial color palette for the chip and brighter accent colors for the animated traces.

### Technical implementation notes
1. Use SVG for the circuit traces, chip, pins, and text.
2. Use plain CSS classes for animation and styling.
3. Animate only the colored trace paths while keeping the background traces static.
4. Do not use JavaScript.
5. Keep the component suitable as a large decorative loading indicator.

### Code fingerprint
```html
<div class="main-container">
  <div class="loader">
    <svg viewBox="0 0 800 500">
      <g id="traces">
        <path class="trace-bg"></path>
        <path class="trace-flow purple"></path>
      </g>
      <rect></rect>
      <text>Loading</text>
    </svg>
  </div>
</div>
```

```css
.trace-bg {
  stroke: #333;
  stroke-width: 1.8;
  fill: none;
}

.trace-flow {
  stroke-width: 1.8;
  fill: none;
  stroke-dasharray: 40 400;
  stroke-dashoffset: 438;
  filter: drop-shadow(0 0 6px currentColor);
  animation: flow 3s cubic-bezier(0.5, 0, 0.9, 1) infinite;
}

@keyframes flow {
  to {
    stroke-dashoffset: 0;
  }
}
```

### Search keywords
circuit chip loader, svg processor loader, flowing traces animation, motherboard loading graphic, animated circuit paths, glowing signal trace loader, central chip loading indicator, futuristic cpu loader, svg loading chip
