# Create minimal underline hover text button
WORKFLOW ==> minimal-underline-hover-text-button

## Visual identity
A pure HTML and CSS minimal text button with uppercase lettering and a clean underline reveal animation. The text starts in a muted light gray and brightens to white on hover or focus, while a thin underline grows outward from the center until it spans the full width of the label.

## Workflow description
Create a pure HTML and CSS text only button with a center outward underline hover animation.

### Required structure
1. Use a single button element.
2. Put a short text label inside the button.
3. Keep the markup minimal with no extra wrapper elements.

### Required styling
1. Use no visible button background.
2. Remove the default border.
3. Use uppercase text.
4. Use a bold font weight around 800.
5. Use a font size around 18px.
6. Use a muted light gray text color in the default state.
7. Keep the button positioned relatively so a pseudo element can be placed under the text.
8. Use smooth transitions around 400ms.
9. Use a cubic bezier easing similar to cubic-bezier(0.25, 0.8, 0.25, 1).

### Required interaction behavior
1. On hover and focus, change the text color from muted gray to white.
2. Use a pseudo element to create a thin underline.
3. Position the underline slightly below the text baseline.
4. Start the underline with zero width and positioned from the horizontal center.
5. On hover and focus, expand the underline to full width.
6. On hover and focus, shift the underline origin so it grows from center outward until aligned to the left edge.
7. Keep the underline white.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the button after pseudo element for the underline animation.
4. Keep the component minimal, elegant, and suitable for navigation or text links.

### Code fingerprint
```html
<button>
  Hover Over
</button>
```

```css
button {
  font-size: 18px;
  color: #e1e1e1;
  font-weight: 800;
  position: relative;
  border: none;
  background: none;
  text-transform: uppercase;
  transition-duration: 400ms;
  transition-property: color;
}

button:hover,
button:focus {
  color: #fff;
}

button:after {
  content: "";
  bottom: -2px;
  left: 50%;
  position: absolute;
  width: 0%;
  height: 2px;
  background-color: #fff;
  transition-duration: 400ms;
  transition-property: width, left;
}

button:hover:after,
button:focus:after {
  width: 100%;
  left: 0%;
}
```

### Search keywords
minimal underline button, text hover underline animation, center outward underline link, uppercase hover button, clean text button hover, pure css underline reveal, navigation text underline effect, elegant hover link button
