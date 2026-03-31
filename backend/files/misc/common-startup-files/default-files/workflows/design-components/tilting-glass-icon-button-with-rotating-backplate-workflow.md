# Create tilting glass icon button with rotating backplate
WORKFLOW ==> tilting-glass-icon-button-with-rotating-backplate

## Visual identity
A pure HTML and CSS compact icon button with a dark backplate and a frosted glass style front layer. On hover, the dark background plate tilts or rotates while the front icon container gains a translucent gray overlay and subtle blur, creating a slick glassmorphism motion effect. The button feels like a modern social or utility icon control.

## Workflow description
Create a pure HTML and CSS square icon button with a rotating dark backplate and glass style hover overlay.

### Required structure
1. Use a button element as the main interactive component.
2. Place one front container element inside the button for the icon surface.
3. Place one background plate element inside the button behind the front container.
4. Put an SVG icon inside the front container.
5. Keep the background plate and front container as separate layers.

### Required styling
1. Style the button as a compact square around 45px by 45px.
2. Use a transparent background on the main button.
3. Remove the default border.
4. Use rounded corners around 7px to 10px.
5. Center all content with flex alignment.
6. Keep the button positioned relatively.
7. Use smooth transitions around 0.3 seconds.
8. Style the front icon container to fill the full button area.
9. Add a subtle semi transparent border around the front container.
10. Keep the front container transparent in the default state.
11. Style the background plate as a dark rectangular layer behind the front surface.
12. Match the backplate corner radius with the front layer.
13. Keep the backplate non interactive using pointer events none.

### Required hover behavior
1. On hover, rotate the dark backplate by about 35 degrees.
2. Set the transform origin near the bottom so the plate feels hinged or tilted.
3. On hover, apply a semi transparent gray overlay to the front container.
4. On hover, add a slight backdrop blur to the front container.
5. Keep the icon centered and visible during the hover effect.

### Required icon behavior
1. Use a monochrome SVG icon centered inside the front container.
2. Keep the icon white in the default state.
3. Size the icon to feel prominent but still comfortably padded.
4. Do not animate the icon independently unless needed for alignment.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use layered span elements for the front glass surface and dark backplate.
4. Use z index or source order so the backplate remains behind the glass layer.
5. Keep the component suitable for social icons such as GitHub or other utility buttons.

### Code fingerprint
```html
<button class="Btn">
  <span class="svgContainer">
    <svg></svg>
  </span>
  <span class="BG"></span>
</button>
```

```css
.Btn {
  width: 45px;
  height: 45px;
  background-color: transparent;
  position: relative;
  border-radius: 7px;
}

.svgContainer {
  width: 100%;
  height: 100%;
  background-color: transparent;
  border: 1px solid rgba(156, 156, 156, 0.466);
  border-radius: 10px;
}

.BG {
  position: absolute;
  width: 100%;
  height: 100%;
  background: #181818;
  z-index: -1;
  border-radius: 10px;
}

.Btn:hover .BG {
  transform: rotate(35deg);
  transform-origin: bottom;
}

.Btn:hover .svgContainer {
  background-color: rgba(156, 156, 156, 0.466);
  backdrop-filter: blur(4px);
}
```

### Search keywords
glass icon button, rotating backplate button, github icon hover button, glassmorphism icon button, tilting background button, frosted icon control, dark backplate hover effect, pure css social icon button
