# Create minimal pill button with expanding center circle hover
WORKFLOW ==> minimal-pill-button-expanding-center-circle-hover

## Visual identity
A pure HTML and CSS minimal pill shaped button with soft translucent text and a subtle outline in the default state. On hover, a bright blue circular fill expands outward from the center behind the label, while the text becomes fully visible and the outer glow intensifies. The button keeps a clean modern look with a smooth active press scale effect.

## Workflow description
Create a pure HTML and CSS rounded pill button with centered text and an expanding circular hover fill effect.

### Required structure
1. Use a button element as the main interactive component.
2. Place one span inside the button for the visible text label.
3. Place a second empty span inside the button for the expanding circular hover fill.
4. Keep the text span above the fill span using layering.

### Required styling
1. Style the button as an inline block or inline button with rounded pill corners.
2. Use padding around 12px 24px.
3. Use no visible solid button background in the default state.
4. Use semi transparent white text in the default state.
5. Add a subtle semi transparent outline or ring using box shadow.
6. Use font size around 16px and font weight around 600.
7. Hide overflow so the expanding fill remains clipped inside the rounded button.
8. Use smooth transitions with a modern cubic bezier timing function.

### Required hover fill behavior
1. Position the second span absolutely in the center of the button.
2. Start it as a small circular element around 20px by 20px.
3. Give it a bright blue background color.
4. Keep it fully transparent by default.
5. On hover, expand it dramatically to around 150px by 150px.
6. On hover, fade it in to full opacity.
7. Keep the expanding circle behind the text.

### Required interaction behavior
1. On hover, increase the outer glow or ring intensity using the same blue accent.
2. On hover, change the text from translucent white to fully visible white.
3. On active or pressed state, scale the button down slightly to around 0.95.
4. Keep all motion smooth and clean.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use absolute positioning for the expanding circle span.
4. Use z index to keep the text above the fill.
5. Keep the component minimal and modern.

### Code fingerprint
```html
<button class="animated-button">
  <span>Hover me</span>
  <span></span>
</button>
```

```css
.animated-button {
  border-radius: 100px;
  color: #ffffff40;
  box-shadow: 0 0 0 2px #ffffff20;
  overflow: hidden;
}

.animated-button span:last-child {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 20px;
  height: 20px;
  background-color: #2196F3;
  border-radius: 50%;
  opacity: 0;
}

.animated-button:hover {
  box-shadow: 0 0 0 5px #2195f360;
  color: #ffffff;
}

.animated-button:hover span:last-child {
  width: 150px;
  height: 150px;
  opacity: 1;
}
```

### Search keywords
minimal pill button, expanding circle hover button, center burst button, blue hover fill button, translucent text button, rounded glow button, pure css expanding hover button, pill cta circle fill
