# Create stacked shadow pressable login button
WORKFLOW ==> stacked-shadow-pressable-login-button

## Visual identity
A pure HTML and CSS button with a soft light gray surface, rounded corners, embossed text, and multiple stacked flat shadows underneath to simulate depth. When pressed, the button moves downward slightly and the shadow stack compresses, creating a satisfying mechanical keycap effect.

## Workflow description
Create a pure HTML and CSS raised button with layered depth shadows and a compressed active press state.

### Required structure
1. Use a single button element.
2. Put a short label inside the button such as Login.
3. Keep the markup minimal with no extra wrapper elements required.

### Required styling
1. Use a neutral light gray button background.
2. Remove the default border.
3. Use a medium to large font size around 1.35rem.
4. Use font weight around 600.
5. Apply inherited font family.
6. Add horizontal padding around 1em and vertical padding around 0.375em.
7. Use rounded corners around 0.5em.
8. Use dark gray text color.
9. Add a subtle light text shadow to make the label look embossed.
10. Create depth using a long stack of layered box shadows beneath the button.
11. Include both very tight top inset highlight and progressively deeper lower shadows.
12. Keep the overall appearance clean, tactile, and slightly retro UI.

### Required interaction behavior
1. On active or pressed state, move the button downward slightly using translate.
2. Compress the box shadow stack in the active state so the button appears pushed in.
3. Keep the transition short and responsive around 0.15 seconds.
4. Use a pointer cursor.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Rely on multiple layered box shadows to create the stacked depth illusion.
4. Keep the component suitable for action buttons such as Login or Submit.

### Code fingerprint
```html
<button>Login</button>
```

```css
button {
  background-color: #f0f0f0;
  border: 0;
  color: #242424;
  border-radius: 0.5em;
  font-size: 1.35rem;
  font-weight: 600;
  text-shadow: 0 0.0625em 0 #fff;
  box-shadow: inset 0 0.0625em 0 0 #f4f4f4, 0 0.0625em 0 0 #efefef,
    0 0.125em 0 0 #ececec, 0 0.25em 0 0 #e0e0e0, 0 0.3125em 0 0 #dedede,
    0 0.375em 0 0 #dcdcdc, 0 0.425em 0 0 #cacaca, 0 0.425em 0.5em 0 #cecece;
}

button:active {
  translate: 0 0.225em;
}
```

### Search keywords
stacked shadow button, pressable login button, raised css button, layered shadow button, mechanical keycap button, embossed text button, active press button, pure css depth button
