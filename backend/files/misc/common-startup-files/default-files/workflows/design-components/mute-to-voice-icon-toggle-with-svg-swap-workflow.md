# Create mute to voice icon toggle with SVG swap
WORKFLOW ==> mute-to-voice-icon-toggle-with-svg-swap

## Visual identity
A pure HTML and CSS audio toggle control that switches between muted and voice enabled states using two overlaid SVG icons. The control uses a clean monochrome icon style, hidden checkbox logic, and a quick pop in animation that makes the active icon rotate slightly and scale into place.

## Workflow description
Create a pure HTML and CSS icon toggle using a hidden checkbox that swaps between mute and voice SVG icons.

### Required structure
1. Use a label element as the clickable wrapper.
2. Place a checkbox input inside the label.
3. Add one SVG icon for the mute state.
4. Add one SVG icon for the voice state.
5. Overlay both icons in the same position.
6. Use sibling selectors so the checkbox state determines which icon is visible.

### Required styling
1. Define CSS variables for icon color and icon size.
2. Style the wrapper as a compact clickable inline flex container.
3. Center content both horizontally and vertically.
4. Keep the wrapper positioned relatively.
5. Use the icon fill color from a muted neutral variable.
6. Set font size from a reusable size variable around 30px.
7. Keep user selection disabled.
8. Keep the component visually minimal and icon only.

### Required icon behavior
1. Position both icons absolutely so they overlap perfectly.
2. Show the mute icon by default.
3. Hide the voice icon by default.
4. When checked, hide the mute icon.
5. When checked, display the voice icon.
6. Apply the same short animated entrance to both icons when they appear.

### Required animation behavior
1. Create a keyframes animation for icon appearance.
2. Start with the icon scaled down to zero and transparent.
3. Mid animation, slightly rotate the icon and scale it above normal size.
4. End at normal visible size.
5. Keep the animation fast around 0.5 seconds.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Hide the native checkbox visually.
4. Use sibling selectors to switch visibility between the two SVG icons.
5. Keep the component suitable for mute or audio state toggles.

### Code fingerprint
```html
<label class="container">
  <input checked="checked" type="checkbox">
  <svg class="mute"></svg>
  <svg class="voice"></svg>
</label>
```

```css
.container {
  --color: #a5a5b0;
  --size: 30px;
  position: relative;
  cursor: pointer;
  font-size: var(--size);
  fill: var(--color);
}

.container .mute {
  position: absolute;
  animation: keyframes-fill .5s;
}

.container .voice {
  position: absolute;
  display: none;
  animation: keyframes-fill .5s;
}

.container input:checked ~ .mute {
  display: none;
}

.container input:checked ~ .voice {
  display: block;
}
```

### Search keywords
mute voice toggle, audio icon switch, svg icon swap toggle, hidden checkbox audio toggle, mute unmute control, pure css icon toggle, speaker icon switch, animated audio state button
