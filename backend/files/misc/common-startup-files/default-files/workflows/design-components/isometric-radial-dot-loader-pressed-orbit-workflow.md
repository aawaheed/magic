# Create isometric radial dot loader with pressed orbit effect
WORKFLOW ==> isometric-radial-dot-loader-pressed-orbit

## Visual identity
A pure HTML and CSS loader made from twelve circular dots arranged in a ring around centered loading text. The whole loader is tilted in an isometric perspective, and each dot has layered pseudo elements that create a pressed mechanical puck effect. The dots animate in sequence so they appear to push inward and light up as they orbit around the center, producing a futuristic radial loading indicator.

## Workflow description
Create a pure HTML and CSS radial loader with twelve animated dots, isometric tilt, centered loading text, and staggered push in and out effects.

### Required structure
1. Use an outer circular loader container.
2. Place twelve child dot elements inside the container.
3. Add a centered text element inside the loader.
4. Use pseudo elements on each dot to create layered top and lower surfaces.
5. Keep all dots absolutely positioned around the center using rotation and translation transforms.

### Required styling
1. Style the main loader as a circular container around 14em by 14em.
2. Use flex centering for the inner text.
3. Apply a 3D or isometric transform to the whole loader using rotateX and rotateZ.
4. Add inset shadows to the outer circular container for depth.
5. Keep the loader text white and uppercase with slight letter spacing.
6. Rotate the text back so it remains visually readable inside the tilted loader.
7. Make each dot circular and relatively small.
8. Add dark shadow depth under each dot so they feel raised or mechanical.

### Required dot behavior
1. Position the dots evenly around the circle using nth child transforms with rotation plus translateX.
2. Use twelve evenly spaced positions around the ring.
3. Give each dot layered pseudo elements so the top surface and lower pressed section can animate independently.
4. Use one pseudo element as the top circular cap.
5. Use the other pseudo element as a lower extruded or pressed segment clipped to the bottom portion.
6. Use rounded shapes and inset highlights to create a tactile puck like appearance.

### Required animation behavior
1. Animate each dot with staggered delays so the motion travels around the circle.
2. Animate the main dot shadow so it appears to deepen and release.
3. Animate the top cap to move diagonally inward during the active part of the cycle.
4. Animate the lower segment clip area so it visually expands upward during the active phase.
5. Use a total animation duration around 2 seconds.
6. Repeat infinitely.
7. Use easing that alternates between ease in and ease out across the keyframes.
8. Keep each dot returning to its original position and color after its active phase.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use nth child selectors to control position, z index, and negative animation delays.
4. Use pseudo elements and clip path to create the pressed mechanical effect.
5. Keep the loader suitable for a futuristic or industrial dashboard style interface.

### Code fingerprint
```html
<div class="pl">
  <div class="pl__dot"></div>
  <div class="pl__dot"></div>
  <div class="pl__dot"></div>
  <div class="pl__text">Loading…</div>
</div>
```

```css
.pl {
  transform: rotateX(30deg) rotateZ(45deg);
  width: 14em;
  height: 14em;
}

.pl__dot:nth-child(1) {
  transform: rotate(0deg) translateX(5em) rotate(0deg);
}

.pl__dot:nth-child(2) {
  transform: rotate(-30deg) translateX(5em) rotate(30deg);
}

.pl__dot:before {
  animation-name: pushInOut1724;
}

.pl__dot:after {
  animation-name: pushInOut2724;
}
```

### Search keywords
isometric dot loader, radial dot spinner, twelve dot loading ring, pressed puck loader, 3d tilted loader, circular dot orbit loader, staggered radial loading animation, futuristic dot ring loader, css isometric spinner
