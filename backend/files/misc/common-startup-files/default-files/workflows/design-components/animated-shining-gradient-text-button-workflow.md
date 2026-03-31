# Create animated shining gradient text button link
WORKFLOW ==> animated-shining-gradient-text-button-workflow

## Visual identity
A pure HTML and CSS call to action link styled as transparent gradient text with a moving shine effect sweeping horizontally across the letters. The text looks metallic or glossy, using background clipped into the text and an infinite linear animation.

## Workflow description
Create a pure HTML and CSS animated text button or call to action link with a shimmering shine effect.

### Required structure
1. Use an anchor element such as an `<a>` tag.
2. Apply a class to the anchor for styling.
3. The element should function visually as a call to action button, but the main effect is on the text itself rather than a boxed button background.

### Required styling
1. Position the element so it can be centered using absolute positioning with translate.
2. Use padding around **12px 48px**.
3. Use a bold modern sans serif font such as **Poppins**.
4. Use font weight around **600** and font size around **16px**.
5. Prevent wrapping with `white-space: nowrap`.
6. Remove underline with `text-decoration: none`.
7. Make the text appear as a **gradient fill** instead of a solid color.
8. Use `background: linear-gradient(...)` with:
   - darker gray
   - bright white highlight
   - darker gray again
9. Use `background-clip: text` and transparent text fill so only the gradient is visible through the letters.
10. Keep the text itself visually white silver or metallic.

### Required interaction and animation
1. Create a keyframes animation named similar to **shine**.
2. Animate the background position horizontally from left to right.
3. Use a duration around **3 seconds**.
4. Use **infinite linear** repetition.
5. Keep the bright highlight band moving across the text to simulate a reflective shimmer.
6. Use `animation-fill-mode: forwards`.

### Code fingerprint
```html
<a href="#" class="btn-shine">Get early access</a>
```

```css
.btn-shine {
  background: linear-gradient(to right, #9f9f9f 0, #fff 10%, #868686 20%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  animation: shine 3s infinite linear;
}

@keyframes shine {
  0% {
    background-position: 0;
  }
  60%,
  100% {
    background-position: 180px;
  }
}
```

### Search keywords
shining text button, gradient text link, animated shine text, glossy text cta, metallic text animation, background clip text shimmer, css shine effect, moving highlight text link
