# Create simple purple toggle switch with sliding knob
WORKFLOW ==> simple-purple-toggle-switch

## Visual identity
A pure HTML and CSS minimal toggle switch built from a hidden checkbox and a label element. The switch has a small rounded dark gray track, a white circular knob created with a pseudo element, and a checked state that changes the track to a soft purple while the knob slides to the right.

## Workflow description
Create a pure HTML and CSS minimal toggle switch using a hidden checkbox and a styled label, with a sliding knob and purple active state.

### Required structure
1. Use an input of type checkbox.
2. Visually hide the checkbox.
3. Place a label immediately after the checkbox.
4. Use the label as the visible toggle track.
5. Use the label after pseudo element as the knob.
6. Link the label to the checkbox using the for attribute and matching id.

### Required styling
1. Style the visible track as a small rounded rectangle around 50px wide and 30px high.
2. Use a dark gray background in the default state.
3. Give the track a fully rounded pill shape with border radius around 20px.
4. Center content with flex alignment if needed.
5. Use pointer cursor on the visible track.
6. Use short transitions around 0.2 seconds.

### Required knob behavior
1. Create the knob using the label after pseudo element.
2. Make the knob a small white circular control.
3. Position it near the left side by default.
4. Add a subtle shadow for depth.
5. On checked state, move the knob horizontally to the right.
6. Keep the movement smooth and compact.

### Required checked state behavior
1. When the checkbox is checked, change the track background to a soft purple or violet tone.
2. When checked, move the knob to the right using a transform.
3. When checked, keep the knob white or brighten it.
4. Use the checkbox checked plus adjacent sibling selector pattern.

### Technical implementation notes
1. Do not use JavaScript.
2. Use a hidden checkbox and label pair.
3. Use a pseudo element for the knob instead of extra markup.
4. Keep the component minimal and lightweight.

### Code fingerprint
```html
<input type="checkbox" id="checkboxInput">
<label for="checkboxInput" class="toggleSwitch"></label>
```

```css
#checkboxInput {
  display: none;
}

.toggleSwitch {
  width: 50px;
  height: 30px;
  background-color: rgb(82, 82, 82);
  border-radius: 20px;
}

.toggleSwitch:after {
  content: "";
  left: 5px;
  border: 5px solid white;
  border-radius: 50%;
}

#checkboxInput:checked + .toggleSwitch {
  background-color: rgb(148, 118, 255);
}

#checkboxInput:checked + .toggleSwitch:after {
  transform: translateX(100%);
  background-color: white;
}
```

### Search keywords
simple purple toggle switch, minimal checkbox toggle, label pseudo element switch, sliding knob toggle, small css switch, hidden checkbox purple switch, pure css pill toggle, adjacent sibling toggle switch
