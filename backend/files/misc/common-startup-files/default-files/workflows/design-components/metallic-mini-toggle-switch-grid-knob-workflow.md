# Create metallic mini toggle switch with grid texture knob
WORKFLOW ==> metallic-mini-toggle-switch-grid-knob

## Visual identity
A pure HTML and CSS compact toggle switch with a metallic light gray outer shell, a recessed track, a warm yellow checked state, and a small sliding knob textured with a grid of tiny circular dimples. The component looks like a polished hardware style mini switch with subtle depth, inset shadows, and a tactile button surface.

## Workflow description
Create a pure HTML and CSS compact toggle switch with a textured sliding knob and warm colored active state.

### Required structure
1. Use an outer wrapper element for the full control.
2. Place a checkbox input inside the wrapper.
3. Place the visible toggle track container immediately after the checkbox.
4. Place a toggle button element inside the track.
5. Inside the button, add a container holding multiple tiny circular elements.
6. Arrange the tiny circles as a small grid to simulate tactile grip texture on the knob.

### Required styling
1. Style the outer wrapper as a compact centered control with:
   - flex alignment
   - relative positioning
   - small padding
   - rounded corners
   - metallic light gray vertical gradient background
2. Add a subtle outer highlight and soft shadow to the wrapper.
3. Hide the native checkbox visually using opacity and absolute positioning while keeping it clickable.
4. Make the checkbox fill the wrapper area and inherit rounded corners.
5. Style the visible track as a small rounded rectangle around 3em by 1.5em.
6. Use a light gray background for the default track state.
7. Add inset highlight and inset shadow to create a recessed channel effect.
8. When checked, change the track color to a warm golden yellow or amber tone.
9. Use smooth transitions around 0.4 seconds for color and knob movement.

### Required knob behavior
1. Create a small rectangular rounded knob positioned absolutely inside the track.
2. Place it near the left edge in the default state.
3. Give the knob a light metallic background with layered inset and outer shadows.
4. On checked state, slide the knob to the right side.
5. Keep the motion smooth and mechanical rather than bouncy.

### Required knob texture
1. Inside the knob, create a grid container using CSS grid.
2. Use multiple tiny circular elements arranged in several columns.
3. Style each circle with a subtle radial gradient from light to darker gray.
4. Keep the circles very small so they read like grip dimples on a physical switch.
5. Center the dimple grid inside the knob.

### Interaction behavior
1. The checkbox should control the visual state using adjacent sibling selectors.
2. The checked selector should change the track color.
3. The checked selector should also move the knob horizontally.
4. No JavaScript should be used.

### Code fingerprint
```html
<div class="toggle-wrapper">
  <input class="toggle-checkbox" type="checkbox">
  <div class="toggle-container">
    <div class="toggle-button">
      <div class="toggle-button-circles-container">
        <div class="toggle-button-circle"></div>
      </div>
    </div>
  </div>
</div>
```

```css
.toggle-checkbox:checked + .toggle-container {
  background-color: #f3b519;
}

.toggle-checkbox:checked + .toggle-container > .toggle-button {
  left: 1.5625em;
}

.toggle-button-circles-container {
  display: grid;
  grid-template-columns: repeat(3, min-content);
}

.toggle-button-circle {
  border-radius: 50%;
  background-image: radial-gradient(circle at 50% 0, #f5f5f5, #c4c4c4);
}
```

### Search keywords
mini toggle switch, metallic toggle, textured knob switch, dimple grid toggle button, yellow active toggle, recessed track switch, compact css toggle, hardware style checkbox switch, tactile mini toggle
