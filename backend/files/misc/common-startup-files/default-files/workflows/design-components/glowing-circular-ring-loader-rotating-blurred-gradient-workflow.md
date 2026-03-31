# Create glowing circular ring loader with rotating blurred gradient
WORKFLOW ==> glowing-circular-ring-loader-rotating-blurred-gradient

## Visual identity
A pure HTML and CSS circular loader with a dark neumorphic outer shell, a recessed inner circular disc, and a warm glowing blurred ring that rotates continuously around the center. The glow uses yellow and orange gradient tones and creates the feeling of a spinning energy halo inside a metallic dark frame.

## Workflow description
Create a pure HTML and CSS glowing circular loader using a rotating blurred gradient layer and an inset inner disc.

### Required structure
1. Use an outer loader container element.
2. Place a single inner span element inside the loader.
3. Use a pseudo element on the loader to create the inner recessed circular disc.
4. Keep the structure minimal and centered around a circular form.

### Required styling
1. Style the outer loader as a perfect circle around 160px by 160px.
2. Use a dark background or dark border tone for the outer shell.
3. Add multiple outer and inset shadows to create a neumorphic or embossed metallic effect.
4. Hide overflow inside the circular container.
5. Add a solid circular border around the outer shell.
6. Use a pseudo element inset from all sides to create a smaller inner circle.
7. Style the inner circle with a dark background, subtle border, and inset shadows for depth.
8. Keep the inner disc above the glow layer visually.

### Required glow behavior
1. Use the inner span as the rotating glow layer.
2. Make it fill the full size of the outer circle.
3. Apply a warm linear gradient using orange, yellow, and pale yellow tones.
4. Blur the glow heavily so it looks like a soft luminous ring.
5. Place the glow behind the recessed inner disc.
6. Keep the glow circular.

### Required animation behavior
1. Animate the glow layer with continuous full rotation.
2. Use a keyframes animation from 0 degrees to 360 degrees.
3. Use a fast linear infinite loop around 0.5 seconds.
4. Keep the motion smooth and uninterrupted.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use a pseudo element for the inner recessed center.
4. Use a blurred gradient span for the rotating luminous ring.
5. Keep the component suitable as a loading indicator or visual accent loader.

### Code fingerprint
```html
<div class="loader">
  <span></span>
</div>
```

```css
.loader {
  width: 160px;
  height: 160px;
  border-radius: 50%;
  overflow: hidden;
}

.loader:before {
  content: "";
  position: absolute;
  top: 25px;
  left: 25px;
  right: 25px;
  bottom: 25px;
  border-radius: 50%;
}

.loader span {
  position: absolute;
  width: 100%;
  height: 100%;
  border-radius: 50%;
  filter: blur(20px);
  animation: animate 0.5s linear infinite;
}

@keyframes animate {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
```

### Search keywords
glowing circular loader, rotating gradient ring, blurred halo loader, neumorphic ring loader, spinning energy ring, dark circular loader, css glowing spinner, inset disc loader, warm gradient loading ring
