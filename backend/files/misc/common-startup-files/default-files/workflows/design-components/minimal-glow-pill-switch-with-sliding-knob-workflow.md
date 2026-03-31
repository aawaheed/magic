# Create minimal glow pill switch with sliding knob
WORKFLOW ==> minimal-glow-pill-switch-with-sliding-knob

## Visual identity
A pure HTML and CSS minimal pill shaped toggle switch with a dark border, smooth rounded track, and a white sliding knob. When turned on, the track border becomes bright blue and emits a soft glow while the knob glides to the right with a springy easing curve.

## Workflow description
Create a pure HTML and CSS compact pill toggle switch using a hidden checkbox, a rounded track, and a sliding circular knob.

### Required structure
1. Use a label element as the outer switch wrapper.
2. Place a checkbox input inside the label.
3. Add a span element after the input to act as the visible slider track.
4. Use a pseudo element on the slider for the knob.

### Required styling
1. Style the switch as a compact horizontal control around 3.5em wide and 2em high.
2. Hide the native checkbox visually.
3. Style the visible track as a rounded pill with full height.
4. Use a dark gray border on the default state.
5. Use a smooth transition on the track around 0.4 seconds.
6. Use an easing curve with a slightly springy or elastic feel.
7. Style the knob as a white circular element inset slightly from the track edges.
8. Keep the knob size around 1.4em by 1.4em.
9. Match the knob corner radius to the pill shape.
10. Keep the component clean and minimal.

### Required checked state behavior
1. When checked, change the track border color to bright blue.
2. Add a soft blue glow around the track.
3. Slide the knob to the right by about 1.5em.
4. Keep both the glow and knob movement animated smoothly.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the hidden checkbox plus adjacent sibling selector pattern.
4. Use the slider before pseudo element as the knob.
5. Keep the component suitable for settings toggles and minimal interfaces.

### Code fingerprint
```html
<label class="switch">
  <input type="checkbox">
  <span class="slider"></span>
</label>
```

```css
.switch {
  width: 3.5em;
  height: 2em;
}

.switch input {
  opacity: 0;
  width: 0;
  height: 0;
}

.slider {
  position: absolute;
  inset: 0;
  border: 2px solid #414141;
  border-radius: 50px;
  transition: all 0.4s cubic-bezier(0.175, 0.885, 0.32, 1.275);
}

.slider:before {
  content: "";
  position: absolute;
  height: 1.4em;
  width: 1.4em;
  left: 0.2em;
  bottom: 0.2em;
  background-color: white;
  border-radius: inherit;
}

.switch input:checked + .slider {
  box-shadow: 0 0 20px rgba(9, 117, 241, 0.8);
  border: 2px solid #0974f1;
}

.switch input:checked + .slider:before {
  transform: translateX(1.5em);
}
```

### Search keywords
minimal pill switch, glow toggle switch, blue neon switch, sliding knob toggle, compact settings switch, pure css pill toggle, modern checkbox switch, glowing border slider
