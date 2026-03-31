# Create neumorphic plus toggle button with press effect
WORKFLOW ==> neumorphic-plus-toggle-button

## Visual identity
A pure HTML and CSS large neumorphic toggle button styled like a soft industrial control pad. It has a square rounded outer housing, a raised circular inner button, a centered plus symbol, and layered highlights and shadows that create a pressed mechanical effect. When pressed or checked, the button appears to sink inward and the label subtly shrinks and darkens.

## Workflow description
Create a pure HTML and CSS neumorphic toggle control with a large circular inner button, centered symbol, and tactile press state.

### Required structure
1. Use an outer container to center the control on the page.
2. Inside it, use a toggle wrapper element for the control.
3. Place a checkbox input inside the toggle.
4. Add one element for the circular button face.
5. Add one element for the centered label or symbol.
6. Use sibling selectors so the checkbox controls the visual states of the button and label.

### Required styling
1. Style the page or wrapper so the control can be centered visually.
2. Style the toggle housing as a large rounded square around 140px by 140px.
3. Use a soft light gray background for the housing.
4. Add strong inset highlights and inset dark shadows to create a neumorphic shell effect.
5. Add a glowing inner highlight using a pseudo element centered in the housing.
6. Style the inner button as a raised circular disc around 96px by 96px.
7. Use layered outer and inset shadows on the button to make it feel elevated and glossy.
8. Slightly blur the button face for a soft rendered look.
9. Style the centered label as a bold large symbol such as a plus sign.
10. Use dark translucent text with subtle embossing and text shadow.

### Required interaction behavior
1. Keep the checkbox invisible but fully clickable across the whole control.
2. On active press, change the circular button shadows so it looks pushed inward.
3. On active press, slightly reduce the label font size.
4. On active press, darken the label slightly.
5. On checked state, maintain a pressed or semi pressed visual state on the button.
6. On checked state, keep the label slightly smaller and darker than the default state.
7. Use smooth transitions around 300ms with a modern cubic bezier easing curve.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use an invisible checkbox over the full control area.
4. Use sibling selectors for active and checked states.
5. Keep the visual style strongly neumorphic and tactile.

### Code fingerprint
```html
<div class="container">
  <div class="toggle">
    <input type="checkbox" />
    <span class="button"></span>
    <span class="label">+</span>
  </div>
</div>
```

```css
.toggle {
  border-radius: 8px;
  background: #ccd0d4;
  height: 140px;
  width: 140px;
}

.toggle:before {
  content: "";
  position: absolute;
  left: 50%;
  top: 50%;
  opacity: 0.2;
}

.toggle .button {
  border-radius: 96.32px;
  position: absolute;
  height: 96.32px;
  width: 96.32px;
  left: 50%;
  top: 50%;
}

.toggle input:active ~ .button {
  box-shadow: inset 0 -8px 30px 1px rgba(255, 255, 255, 0.9), inset 0 8px 25px 0 rgba(0, 0, 0, 0.4);
}

.toggle input:checked ~ .label {
  font-size: 40px;
}
```

### Search keywords
neumorphic plus toggle, soft ui button switch, industrial press button, raised circular toggle, neumorphic control pad, plus symbol button, tactile checkbox button, pure css neumorphic toggle
