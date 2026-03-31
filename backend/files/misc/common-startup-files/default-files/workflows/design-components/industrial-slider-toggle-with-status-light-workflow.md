# Create industrial slider toggle with status light
WORKFLOW ==> industrial-slider-toggle-with-status-light

## Visual identity
A pure HTML and CSS industrial style horizontal toggle switch with a dark mechanical housing, a sliding half width handle, a small indicator light, and a central grip made from three vertical bars. In the default state the indicator glows red, and when toggled on the handle slides to the right and the indicator changes to a green glow.

## Workflow description
Create a pure HTML and CSS mechanical slider toggle using a hidden checkbox, a sliding label handle, a status light, and a center grip detail.

### Required structure
1. Use an outer switch container element.
2. Place a checkbox input inside the switch.
3. Add a label immediately after the input and link it using matching id and for attributes.
4. Inside the label, place one inner element to act as the grip detail.
5. Build the grip as a central vertical bar with two side bars using pseudo elements.

### Required styling
1. Style the outer switch as a wide dark rectangle around 210px by 50px.
2. Add a small inner padding around 3px.
3. Use a very dark background for the housing.
4. Add subtle inset and outer highlights for a metallic recessed look.
5. Use rounded corners around 6px for the housing.
6. Hide the checkbox visually while keeping it clickable across the whole control.
7. Style the label as a half width sliding handle.
8. Use a slightly lighter dark tone for the handle.
9. Give the handle rounded corners and an inset top highlight.
10. Animate handle movement smoothly around 0.5 seconds.

### Required indicator behavior
1. Add a small circular indicator light using the label before pseudo element.
2. Position the light near the left side of the handle.
3. Make the default glow red.
4. Use layered box shadow to create a bright LED effect.
5. When checked, switch the indicator glow to green.

### Required grip behavior
1. Place a narrow vertical grip bar at the visual center of the handle.
2. Duplicate it left and right using pseudo elements.
3. Use subtle highlights so the bars look slightly raised.
4. Keep the grip dark to match the mechanical style.

### Required checked state behavior
1. When checked, slide the handle from the left half to the right half of the switch.
2. Keep the handle exactly aligned within the container.
3. Change the indicator light from red glow to green glow.
4. Preserve the same smooth transition timing for both movement and light change.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use a hidden checkbox plus adjacent sibling label pattern.
4. Use pseudo elements for the status light and extra grip bars.
5. Keep the component suitable for power, system state, or equipment controls.

### Code fingerprint
```html
<div class="switch">
  <input id="toggle" type="checkbox" />
  <label class="toggle" for="toggle">
    <i></i>
  </label>
</div>
```

```css
.switch {
  position: relative;
  width: 210px;
  height: 50px;
  padding: 3px;
  background: #0d0d0d;
  border-radius: 6px;
}

.switch input[type="checkbox"] + label {
  position: relative;
  left: 0;
  width: 50%;
  height: 100%;
  background: #1b1c1c;
  border-radius: 3px;
  transition: all 0.5s ease-in-out;
}

.switch input[type="checkbox"] + label:before {
  content: "";
  width: 5px;
  height: 5px;
  background: #fff;
  border-radius: 50%;
  box-shadow:
    0 0 5px 2px rgba(165, 15, 15, 0.9),
    0 0 3px 1px rgba(165, 15, 15, 0.9);
}

.switch input[type="checkbox"]:checked + label {
  left: 50%;
}

.switch input[type="checkbox"]:checked + label:before {
  box-shadow:
    0 0 5px 2px rgba(15, 165, 70, 0.9),
    0 0 3px 1px rgba(15, 165, 70, 0.9);
}
```

### Search keywords
industrial toggle switch, mechanical slider switch, led status toggle, red green indicator switch, dark hardware toggle, sliding half handle switch, pure css industrial control, equipment power toggle
