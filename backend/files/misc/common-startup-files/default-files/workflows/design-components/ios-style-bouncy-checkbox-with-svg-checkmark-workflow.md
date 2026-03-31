# Create iOS style bouncy checkbox with SVG checkmark
WORKFLOW ==> ios-style-bouncy-checkbox-with-svg-checkmark

## Visual identity
A pure HTML and CSS modern checkbox styled like a polished iOS inspired control with rounded square corners, soft focus ring, subtle hover scaling, and a smooth bounce when checked. The checkmark is drawn using an SVG path animation, and the component supports theme variants such as blue or red by overriding CSS variables.

## Workflow description
Create a pure HTML and CSS rounded checkbox with animated SVG checkmark drawing, hover scale, focus ring, and checked bounce effect.

### Required structure
1. Use an outer wrapper element to group one or more checkbox controls.
2. For each control, use a label element as the clickable wrapper.
3. Place a checkbox input inside the label.
4. Add a wrapper element immediately after the input.
5. Inside the wrapper, add a background layer element.
6. Inside the wrapper, add an SVG element for the check icon.
7. Inside the SVG, add a path element for the animated check stroke.

### Required styling
1. Define CSS variables for checkbox size, active color, focus background, and border color.
2. Style the checkbox as a rounded square around 28px by 28px.
3. Keep the native checkbox hidden.
4. Use a white default background on the visual checkbox.
5. Add a soft colored border around the checkbox.
6. Use rounded corners around 8px.
7. Keep the visual wrapper positioned relatively.
8. Use smooth transitions around 0.2 to 0.3 seconds.
9. Style the SVG icon in white.
10. Keep the icon slightly inset and centered inside the box.

### Required checked state behavior
1. When checked, change the checkbox background to the active theme color.
2. When checked, change the border color to match the active color.
3. Scale the icon from zero to full size.
4. Animate the SVG path using stroke dash array and stroke dash offset so the checkmark draws in.
5. Apply a short bounce animation to the wrapper when the checkbox becomes checked.

### Required interaction behavior
1. On hover, scale the checkbox wrapper slightly up.
2. On active press, scale the wrapper slightly down.
3. On keyboard focus, show a soft focus ring using the theme background color.
4. Keep the control feeling crisp, modern, and touch friendly.

### Required variant behavior
1. Support theme variants by overriding CSS variables on modifier classes.
2. Include at least one variant class such as red.
3. Let the variant change the active color, focus ring color, and border tone.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the input checked plus adjacent sibling selector pattern.
4. Use SVG for the checkmark so the stroke can animate cleanly.
5. Keep the component suitable for modern mobile inspired forms and settings screens.

### Code fingerprint
```html
<div class="checkbox-container">
  <label class="ios-checkbox red">
    <input type="checkbox" />
    <div class="checkbox-wrapper">
      <div class="checkbox-bg"></div>
      <svg class="checkbox-icon" viewBox="0 0 24 24" fill="none">
        <path class="check-path" d="M4 12L10 18L20 6"></path>
      </svg>
    </div>
  </label>
</div>
```

```css
.ios-checkbox {
  --checkbox-size: 28px;
  --checkbox-color: #3b82f6;
  --checkbox-bg: #dbeafe;
  --checkbox-border: #93c5fd;
}

.checkbox-wrapper {
  width: var(--checkbox-size);
  height: var(--checkbox-size);
  border-radius: 8px;
}

.checkbox-bg {
  border: 2px solid var(--checkbox-border);
  background: white;
}

.checkbox-icon {
  transform: scale(0);
}

.check-path {
  stroke-dasharray: 40;
  stroke-dashoffset: 40;
}

.ios-checkbox input:checked + .checkbox-wrapper .check-path {
  stroke-dashoffset: 0;
}
```

### Search keywords
ios checkbox, bouncy checkbox, svg checkmark animation, rounded modern checkbox, focus ring checkbox, animated tick path checkbox, mobile style checkbox, themeable checkbox component
