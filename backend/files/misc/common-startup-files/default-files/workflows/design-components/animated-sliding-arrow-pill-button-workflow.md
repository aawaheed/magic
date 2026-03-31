# Create animated sliding arrow pill button with expanding circle
WORKFLOW ==> animated-sliding-arrow-pill-button

## Visual identity
A pure HTML and CSS rounded pill shaped button with neon style outline coloring, centered text, two arrow icons, and an expanding circular fill effect on hover. One arrow starts visible on the right, the second arrow slides in from the left, the text shifts horizontally, the background fill expands from the center, and the button changes from a fully rounded pill to a softer rounded rectangle.

## Workflow description
Create a pure HTML and CSS animated button with layered icon motion and a circular hover fill effect.

### Required structure
1. Use a button element as the main interactive component.
2. Place two SVG arrow icons inside the button.
3. Add a text span inside the button.
4. Add a separate span element for the expanding circular fill effect.
5. Give the two arrow icons separate classes so they can animate independently.
6. Keep all animated elements inside the button container.

### Required styling
1. Style the button as a horizontal pill shaped control with:
   - flex layout
   - vertical centering
   - small gap between items
   - padding around 16px 36px
   - very large border radius around 100px
2. Use a transparent or inherited background in the default state.
3. Use a visible outline effect with a bright green or greenyellow accent color.
4. Add a box shadow that looks like a 2px outer ring in the accent color.
5. Set the text color to the same bright accent color.
6. Use font weight around 600 and font size around 16px.
7. Hide overflow so animated icons and fill effects remain clipped inside the button.
8. Use smooth cubic bezier transitions with a slightly dramatic motion feel.

### Required icon and text behavior
1. Position both SVG arrow icons absolutely.
2. Keep one arrow visible near the right edge in the default state.
3. Place the second arrow outside the left side initially.
4. Keep the text slightly shifted left in the default state.
5. On hover:
   - move the right arrow out toward the right
   - move the left arrow into view near the left inner edge
   - shift the text slightly to the right
6. Change the arrow color on hover to a dark contrasting color.

### Required circle fill behavior
1. Add a circular span centered inside the button.
2. Start it small, hidden, and transparent.
3. On hover, expand it dramatically to fill most or all of the button interior.
4. Use the same bright accent color for the circle.
5. Keep the circle behind the text and icons but inside the button.

### Required button state changes
1. On hover:
   - remove or soften the outer accent ring
   - change the text color to a dark color such as near black
   - reduce the border radius from pill shaped to around 12px
2. On active or pressed state:
   - slightly scale the button down to around 0.95
   - restore a smaller accent ring or glow

### Motion characteristics
1. Use longer smooth transitions around 0.6s to 0.8s.
2. Use cubic bezier easing similar to:
   - cubic-bezier(0.23, 1, 0.32, 1)
3. Keep the animation feeling fluid, modern, and slightly elastic.

### Code fingerprint
```html
<button class="animated-button">
  <svg class="arr-2"></svg>
  <span class="text">Modern Button</span>
  <span class="circle"></span>
  <svg class="arr-1"></svg>
</button>
```

```css
.animated-button {
  border-radius: 100px;
  box-shadow: 0 0 0 2px greenyellow;
  overflow: hidden;
}

.animated-button .arr-1 {
  right: 16px;
}

.animated-button .arr-2 {
  left: -25%;
}

.animated-button .text {
  transform: translateX(-12px);
}

.animated-button:hover .arr-1 {
  right: -25%;
}

.animated-button:hover .arr-2 {
  left: 16px;
}

.animated-button:hover .text {
  transform: translateX(12px);
}

.animated-button:hover .circle {
  width: 220px;
  height: 220px;
  opacity: 1;
}
```

### Search keywords
animated button, sliding arrow button, pill button hover effect, expanding circle button, dual arrow icon button, neon outline button, modern cta button, hover fill button, svg arrow transition button, rounded animated button
