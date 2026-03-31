# Create rose button with expanding blob hover effect
WORKFLOW ==> rose-button-expanding-blob-hover

## Visual identity
A pure HTML and CSS bold rose colored button with rounded corners, large text, and dramatic text shadow. On hover, a small dark rose shape rises from the bottom and expands massively behind the label, creating a liquid blob or burst effect while the text shadow softens to a lighter pink tone.

## Workflow description
Create a pure HTML and CSS button with a centered label, strong text shadow, and a pseudo element that expands into a large dark rose hover fill.

### Required structure
1. Use a single button element.
2. Place a short label inside the button such as Hover Me.
3. Keep the markup minimal with no extra child elements required.
4. Use a pseudo element for the hover burst effect.

### Required styling
1. Style the button as a medium large rectangular control with rounded corners.
2. Use a rose or pink background color in the default state.
3. Use white text.
4. Use a large font size around 1.5rem.
5. Use a semibold or bold weight.
6. Add generous padding around 1rem vertically and 2rem horizontally.
7. Set the button to position relative and hide overflow.
8. Remove the default border.
9. Add a strong dark rose text shadow in the default state.
10. Use smooth transitions around 0.7 seconds.

### Required hover effect behavior
1. Create an after pseudo element positioned near the lower left area of the button.
2. Start the pseudo element as a very small rounded square or dot.
3. Use a dark rose background color for the pseudo element.
4. Position it initially below the visible button area using translateY.
5. Keep the pseudo element behind the text using negative z index or appropriate layering.
6. On hover, move the pseudo element upward into view.
7. On hover, scale it dramatically so it fills and exceeds the button area.
8. Keep the expansion smooth and slightly theatrical.

### Required text behavior
1. In the default state, use a large pronounced text shadow.
2. On hover, soften or reduce the text shadow intensity.
3. Use a lighter pink text shadow on hover.
4. Keep the text readable while the hover blob expands behind it.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Do not rely on Tailwind utility classes.
4. Use a button after pseudo element for the burst fill effect.
5. Keep the component suitable for playful call to action buttons.

### Code fingerprint
```html
<button class="rose-hover-button">
  Hover Me
</button>
```

```css
.rose-hover-button {
  position: relative;
  overflow: hidden;
  padding: 1rem 2rem;
  border: none;
  border-radius: 0.375rem;
  background: #fb7185;
  color: white;
  font-size: 1.5rem;
  font-weight: 600;
  text-shadow: 3px 5px 2px #be123c;
  transition: all 0.7s;
}

.rose-hover-button:after {
  content: "";
  position: absolute;
  left: 1.25rem;
  bottom: 0;
  width: 0.25rem;
  height: 0.25rem;
  border-radius: 0.375rem;
  background: #9f1239;
  transform: translateY(100%);
  transition: all 0.7s;
}

.rose-hover-button:hover {
  text-shadow: 2px 2px 2px #fda4af;
}

.rose-hover-button:hover:after {
  transform: translateY(0) scale(300);
}
```

### Search keywords
rose hover button, expanding blob button, pink burst hover button, pseudo element fill button, dramatic hover cta, text shadow hover button, pure css rose button, expanding dark fill effect
