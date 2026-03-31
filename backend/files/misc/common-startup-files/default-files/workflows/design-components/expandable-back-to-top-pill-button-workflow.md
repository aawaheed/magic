# Create expandable back to top pill button from circular icon
WORKFLOW ==> expandable-back-to-top-pill-button

## Visual identity
A pure HTML and CSS floating action style button that starts as a small dark circular icon button with a soft purple outer ring. On hover, it expands horizontally into a rounded pill, changes to a light purple background, slides the arrow icon upward out of view, and reveals the text Back to Top inside the button.

## Workflow description
Create a pure HTML and CSS circular action button that expands into a pill shaped label button on hover.

### Required structure
1. Use a button element as the main interactive component.
2. Place a single SVG icon inside the button.
3. Use a pseudo element on the button to display the hover label text.
4. Keep the initial markup minimal with no extra text node required inside the button.

### Required styling
1. Style the button as a small circle around 50px by 50px.
2. Use a very dark background in the default state.
3. Remove the default border.
4. Center the icon using flex layout.
5. Add a soft purple outer ring or glow using box shadow.
6. Use overflow hidden so the icon and label transition stay clipped cleanly.
7. Use smooth transitions around 0.3 seconds.
8. Keep the button positioned relatively so the pseudo element can be placed inside it.

### Required icon behavior
1. Use an upward arrow SVG icon.
2. Keep the icon small and white in the default state.
3. On hover, move the icon upward and out of view.
4. Keep the icon transition synchronized with the button expansion.

### Required hover behavior
1. On hover, expand the button width to around 140px.
2. On hover, change the border radius from a circle to a pill shape around 50px.
3. On hover, change the background to a light purple accent.
4. Keep the content centered during the expansion.
5. Reveal the text Back to Top using a pseudo element.
6. Start the pseudo element text hidden with font size zero and positioned low.
7. On hover, increase the pseudo element font size to around 13px and move it into visible centered position.
8. Keep the revealed label text white.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use a button pseudo element for the hover label text.
4. Use transform on the icon to move it out of view.
5. Keep the component suitable for scroll to top or utility actions.

### Code fingerprint
```html
<button class="button">
  <svg class="svgIcon"></svg>
</button>
```

```css
.button {
  width: 50px;
  height: 50px;
  border-radius: 50%;
  background-color: rgb(20, 20, 20);
  box-shadow: 0 0 0 4px rgba(180, 160, 255, 0.253);
}

.button:hover {
  width: 140px;
  border-radius: 50px;
  background-color: rgb(181, 160, 255);
}

.button:hover .svgIcon {
  transform: translateY(-200%);
}

.button:before {
  content: "Back to Top";
  font-size: 0;
}

.button:hover:before {
  font-size: 13px;
}
```

### Search keywords
back to top button, expanding circle to pill button, hover reveal label button, floating utility button, arrow icon expand button, purple pill hover button, pure css back to top control, expanding icon label button
