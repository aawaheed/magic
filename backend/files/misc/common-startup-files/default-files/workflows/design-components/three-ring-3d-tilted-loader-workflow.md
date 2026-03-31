# Create three ring 3D tilted loader with animated border rotation
WORKFLOW ==> three-ring-3d-tilted-loader

## Visual identity
A pure HTML and CSS 3D style loader made from three concentric circular rings tilted in perspective. Each ring uses thick outset borders in blue teal tones and animates through subtle rotation, depth shift, and color change, creating the look of layered orbiting discs or futuristic rotating rings.

## Workflow description
Create a pure HTML and CSS loader using three concentric circular rings with 3D tilt, staggered animation, and shifting border colors.

### Required structure
1. Use an outer loader container element.
2. Place three child elements inside the loader.
3. Use the same base class for all rings.
4. Let each ring vary by size, border thickness, color, and animation delay using nth child selectors.

### Required styling
1. Style the outer container around 200px by 200px.
2. Add perspective to the outer container so the inner rings appear tilted in 3D space.
3. Position each ring absolutely in the center of the container.
4. Make each ring a perfect circle using full border radius.
5. Use transparent background for the rings.
6. Use thick outset borders instead of solid fills.
7. Set transform origin to the center of each ring.
8. Apply a default 3D transform using rotateX, rotateY, rotateZ, and translateZ.
9. Use blue and teal family colors across the rings.

### Required ring variations
1. The first ring should be the smallest and thickest.
2. The second ring should be slightly larger with a thinner border.
3. The third ring should be the largest with the thinnest border.
4. Offset their animation start times slightly using short delays.
5. Add inset shadow detail to the larger rings.

### Required animation behavior
1. Animate each ring with its own keyframes.
2. Start each ring in a tilted resting position with negative depth using translateZ.
3. Mid animation, rotate the ring further on the Z axis, slightly adjust X tilt, and move it forward in depth.
4. Return the ring to its original resting transform at the end.
5. Change the border color during the middle of the animation to a greener or alternate teal tone.
6. For some rings, also animate inset shadow intensity.
7. Use a smooth infinite loop around 1000ms.
8. Use a cubic bezier timing function similar to cubic-bezier(.49,.06,.43,.85).

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use nth child selectors to define ring size and timing differences.
4. Use perspective on the parent and 3D transforms on the children.
5. Keep the animation feeling futuristic, layered, and orbital.

### Code fingerprint
```html
<div class="loader">
  <div class="dot"></div>
  <div class="dot"></div>
  <div class="dot"></div>
</div>
```

```css
.loader {
  width: 200px;
  height: 200px;
  perspective: 200px;
}

.dot {
  position: absolute;
  top: 50%;
  left: 50%;
  border-radius: 100px;
  transform-origin: 50% 50%;
  transform: rotateX(24deg) rotateY(20deg) rotateZ(0deg) translateZ(-25px);
  animation: dot1 1000ms cubic-bezier(.49,.06,.43,.85) infinite;
}

.dot:nth-child(2) {
  animation-name: dot2;
  animation-delay: 75ms;
}

.dot:nth-child(3) {
  animation-name: dot3;
  animation-delay: 150ms;
}
```

### Search keywords
3d ring loader, concentric ring spinner, tilted circular loader, perspective ring animation, futuristic orbit loader, layered border ring loader, blue teal rotating rings, css 3d loader, concentric dot ring animation
