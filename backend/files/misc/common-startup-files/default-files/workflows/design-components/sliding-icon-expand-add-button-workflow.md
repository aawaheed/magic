# Create sliding icon expand add button
WORKFLOW ==> sliding-icon-expand-add-button

## Visual identity
A pure HTML and CSS green action button with a text label on the left and a compact icon block on the right. On hover, the icon section expands to cover almost the full button width while the text fades away, creating a sliding reveal effect. The result feels like a modern add action button with a strong directional motion.

## Workflow description
Create a pure HTML and CSS action button with a sliding icon panel that expands across the button on hover.

### Required structure
1. Use a button element as the main interactive component.
2. Place one span inside for the text label.
3. Place one span inside for the icon container.
4. Put an inline SVG plus icon inside the icon container.
5. Keep the icon container positioned separately from the text so it can animate independently.

### Required styling
1. Style the button as a horizontal rectangular control around 150px by 40px.
2. Use a medium green background for the main button.
3. Add a slightly darker green border.
4. Use flex alignment to vertically center content.
5. Keep the component clickable with pointer cursor.
6. Use smooth transitions around 0.3 seconds.
7. Style the text in white with medium bold weight.
8. Offset the text slightly to the right in the default state.
9. Style the icon section as an absolutely positioned block on the right side.
10. Make the icon section slightly darker than the main button background.
11. Center the SVG icon inside the icon section.
12. Use a white stroked plus icon.

### Required hover behavior
1. On hover, darken the full button background slightly.
2. Fade the text label to transparent.
3. Expand the icon section from a narrow right side block to nearly the full width of the button.
4. Move the icon section so it aligns from the left edge after expansion.
5. Keep the icon centered during the expansion.

### Required active behavior
1. On active press, darken the icon section further.
2. On active press, darken the border color as well.
3. Keep the interaction crisp and responsive.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use absolute positioning for the icon panel.
4. Use text transparency rather than removing the text element on hover.
5. Keep the component suitable for add item or create item actions.

### Code fingerprint
```html
<button type="button" class="button">
  <span class="button__text">Add Item</span>
  <span class="button__icon"><svg class="svg"></svg></span>
</button>
```

```css
.button {
  position: relative;
  width: 150px;
  height: 40px;
  border: 1px solid #34974d;
  background-color: #3aa856;
}

.button .button__text {
  transform: translateX(30px);
  color: #fff;
}

.button .button__icon {
  position: absolute;
  transform: translateX(109px);
  width: 39px;
  background-color: #34974d;
}

.button:hover .button__text {
  color: transparent;
}

.button:hover .button__icon {
  width: 148px;
  transform: translateX(0);
}
```

### Search keywords
sliding icon button, add item button, expanding icon panel button, hover reveal action button, green add button, plus icon sliding button, pure css expanding icon button, animated cta with icon panel
