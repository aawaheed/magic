# Create neon power button toggle switch
WORKFLOW ==> neon-power-button-toggle-switch

## Visual identity
A pure HTML and CSS circular power toggle styled like a dark hardware button with a centered power icon. In the default state it appears muted and metallic, and when activated it glows with a bright cyan neon aura, brightens the icon to white, and gains layered inner and outer light effects.

## Workflow description
Create a pure HTML and CSS circular power button toggle using a hidden checkbox and a label with a centered power icon.

### Required structure
1. Use an input of type checkbox as the hidden state controller.
2. Place a label immediately after the checkbox.
3. Use the label as the visible circular power button.
4. Place an SVG power icon inside the label.
5. Link the label to the checkbox using matching id and for attributes.

### Required styling
1. Hide the checkbox from view.
2. Style the label as a circular button around 70px by 70px.
3. Use a dark gray background in the default state.
4. Add a slightly lighter gray border.
5. Center the icon inside the button using flex layout.
6. Add a subtle inset shadow for a recessed hardware look.
7. Keep the cursor as pointer.
8. Use a perfect circular border radius.

### Required icon behavior
1. Use a centered SVG power symbol icon.
2. Keep the icon relatively small, around 1.2em wide.
3. Use a dark muted fill color in the default state.
4. When checked, brighten the icon to white.
5. When checked, add a cyan glow to the icon using drop shadow.

### Required checked state behavior
1. When the checkbox is checked, change the button background to a lighter blue gray tone.
2. Change the border to white.
3. Add multiple inset and outer cyan glow layers.
4. Include a large soft outer glow to create a neon powered on effect.
5. Keep the button looking like it has switched on electrically.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the checkbox checked plus adjacent sibling selector pattern.
4. Keep the component suitable for power, enable, or neon hardware toggle interfaces.

### Code fingerprint
```html
<input id="checkbox" type="checkbox" />
<label class="switch" for="checkbox">
  <svg class="slider"></svg>
</label>
```

```css
#checkbox {
  display: none;
}

.switch {
  width: 70px;
  height: 70px;
  background-color: rgb(99, 99, 99);
  border-radius: 50%;
  border: 2px solid rgb(126, 126, 126);
  box-shadow: 0 0 3px rgb(2, 2, 2) inset;
}

#checkbox:checked + .switch {
  box-shadow: 0 0 1px rgb(151, 243, 255) inset,
    0 0 2px rgb(151, 243, 255) inset,
    0 0 10px rgb(151, 243, 255) inset,
    0 0 40px rgb(151, 243, 255),
    0 0 100px rgb(151, 243, 255),
    0 0 5px rgb(151, 243, 255);
  border: 2px solid rgb(255, 255, 255);
  background-color: rgb(146, 180, 184);
}

#checkbox:checked + .switch svg path {
  fill: rgb(255, 255, 255);
}
```

### Search keywords
neon power button, glowing power toggle, circular power switch, cyan glow toggle, hardware power icon button, hidden checkbox power switch, pure css neon toggle, illuminated power button
