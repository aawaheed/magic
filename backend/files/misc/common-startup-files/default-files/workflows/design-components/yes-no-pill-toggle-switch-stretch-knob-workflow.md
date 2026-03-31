# Create yes no pill toggle switch with stretching text knob
WORKFLOW ==> yes-no-pill-toggle-switch-stretch-knob

## Visual identity
A pure HTML and CSS pill shaped toggle switch with a soft blue track, a circular sliding knob that contains text, and a checked state that changes both the knob label and the background tone. In the default state the knob says YES in blue, and in the checked state it slides right, changes to red, and says NO. When pressed, the knob stretches horizontally for a tactile elastic effect.

## Workflow description
Create a pure HTML and CSS text based toggle switch with a sliding labeled knob, soft background layer, and active stretch animation.

### Required structure
1. Use an outer wrapper element for the toggle control.
2. Inside it, use a button sized toggle container with rounded pill corners.
3. Place a checkbox input inside the toggle.
4. Add a separate element for the knob layer.
5. Add a separate element for the background layer.
6. Use the checkbox state to control the knob label, knob position, and background color.

### Required styling
1. Style the main toggle as a compact pill around 74px by 36px.
2. Use a rounded pill shape for both the main toggle and the background layer.
3. Keep the checkbox invisible but fully clickable above the visual layers.
4. Use a light blue background layer in the default state.
5. Make the visual layout clean, soft, and modern.
6. Use smooth transitions around 0.3 seconds.

### Required knob behavior
1. Create the visible knob using a pseudo element on the knob layer.
2. In the default state, place the knob near the left side.
3. Make the knob circular with centered text.
4. Show the text YES in the default state.
5. Use a bright blue knob background in the default state.
6. When checked, move the knob to the right side.
7. When checked, change the knob text to NO.
8. When checked, change the knob background to red.

### Required active press behavior
1. When the checkbox is actively pressed, stretch the knob horizontally.
2. Change the knob from a circle to a pill like stretched shape while active.
3. If the toggle is already checked and actively pressed, offset the stretched knob so it still aligns correctly on the right side.
4. Keep the motion elastic using a cubic bezier curve for the horizontal position.

### Required background behavior
1. Use a separate layer behind the knob.
2. In the default state, keep it light blue.
3. In the checked state, change it to a soft light red or pink tone.
4. Animate the background color smoothly.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the checkbox plus sibling selector pattern for all visual state changes.
4. Use a pseudo element for the knob so the label text can switch between YES and NO.
5. Keep the control compact and tactile.

### Code fingerprint
```html
<div class="toggle-button-cover">
  <div id="button-3" class="button r">
    <input class="checkbox" type="checkbox">
    <div class="knobs"></div>
    <div class="layer"></div>
  </div>
</div>
```

```css
#button-3 .knobs:before {
  content: "YES";
  left: 4px;
  background-color: #03a9f4;
  border-radius: 50%;
}

#button-3 .checkbox:active + .knobs:before {
  width: 46px;
  border-radius: 100px;
}

#button-3 .checkbox:checked + .knobs:before {
  content: "NO";
  left: 42px;
  background-color: #f44336;
}

#button-3 .checkbox:checked ~ .layer {
  background-color: #fcebeb;
}
```

### Search keywords
yes no toggle switch, text knob toggle, pill switch with labels, stretch knob toggle, blue red toggle switch, checkbox sibling toggle, tactile css switch, sliding yes no button, pure css labeled toggle
