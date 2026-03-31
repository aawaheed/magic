# Create gradient flip hover button with 3D overlay
WORKFLOW ==> gradient-flip-hover-button-with-3d-overlay

## Visual identity
A pure HTML and CSS bold uppercase button with a transparent base, rounded corners, and a glossy gradient overlay panel. On hover, the overlay performs a 3D flip style rotation, giving the button a sleek animated card like shimmer effect with blue and purple tones.

## Workflow description
Create a pure HTML and CSS uppercase button with a full size gradient overlay that flips in 3D on hover.

### Required structure
1. Use a button element as the main interactive component.
2. Place a short text label inside the button.
3. Optionally wrap the label in an inline element if needed for layering.
4. Use a pseudo element on the button as the animated overlay surface.

### Required styling
1. Style the button with a transparent background.
2. Use white text.
3. Use uppercase lettering.
4. Use a bold font weight around 600.
5. Use a font size around 17px.
6. Add generous padding around 20px by 30px.
7. Remove the default border.
8. Use rounded corners around 10px.
9. Add a soft outer shadow beneath the button.
10. Apply perspective to the button so the overlay rotation feels three dimensional.
11. Keep the button positioned so the pseudo element can cover the full surface.

### Required overlay behavior
1. Create a full size pseudo element covering the button.
2. Match the pseudo element border radius to the button corners.
3. Use a diagonal blue to purple semi transparent gradient background.
4. Keep the overlay above the base surface.
5. On hover, animate the overlay with a Y axis rotation.
6. Use a keyframes animation that starts around 180 degrees and ends around 360 degrees.
7. Keep the hover animation around 1 second.
8. Allow the gradient or overlay transition to feel smooth and glossy.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the button before pseudo element for the animated face.
4. Keep the component suitable for hero buttons or decorative call to action buttons.

### Code fingerprint
```html
<button>
  <a>Hover me</a>
</button>
```

```css
button {
  background: transparent;
  color: #fff;
  font-size: 17px;
  text-transform: uppercase;
  font-weight: 600;
  border: none;
  padding: 20px 30px;
  perspective: 30rem;
  border-radius: 10px;
}

button:before {
  content: "";
  position: absolute;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  border-radius: 10px;
  background: linear-gradient(320deg, rgba(0, 140, 255, 0.678), rgba(128, 0, 128, 0.308));
}

button:hover:before {
  animation: rotate 1s;
}

@keyframes rotate {
  0% {
    transform: rotateY(180deg);
  }
  100% {
    transform: rotateY(360deg);
  }
}
```

### Search keywords
gradient flip button, 3d overlay hover button, rotating gradient button, blue purple hover cta, glossy flip button, perspective hover button, pure css gradient rotation button, animated overlay button
