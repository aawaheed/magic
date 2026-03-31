# Create interactive glow generate button with morphing text
WORKFLOW ==> interactive-glow-generate-button-morphing-text

## Visual identity
A pure HTML and CSS dark glossy button with a subtle glassy surface, layered inset and outer shadows, a glowing star style icon, and animated letters that flicker individually. The button has a futuristic neon highlight effect, and on focus the text morphs from Generate to Generating while the letters bloom, blur, and glow in sequence. Hover and active states intensify the highlight and make the component feel reactive and premium.

## Workflow description
Create a pure HTML and CSS futuristic dark button with glowing icon, animated letters, layered depth, and a focus state that morphs the text from one word to another.

### Required structure
1. Use an outer wrapper element for positioning.
2. Inside it, use a button element as the main interactive control.
3. Add an SVG icon element near the left side of the button.
4. Add a text wrapper element beside the icon.
5. Inside the text wrapper, add two separate text layers.
6. The first text layer should contain individual span elements for each letter of the default word.
7. The second text layer should contain individual span elements for each letter of the alternate focus word.
8. Stack the two text layers so one can fade out while the other fades in.

### Required styling
1. Style the button as a dark rounded pill or capsule shape with border radius around 24px.
2. Use a nearly black background color.
3. Add multiple inset white highlights and subtle outer shadow layers to create a glossy premium surface.
4. Add a faint border using semi transparent white.
5. Use smooth transitions around 0.4 seconds.
6. Use a clean modern font such as Poppins, Inter, or Segoe UI.
7. Add slightly asymmetric padding so the text has more room than the icon side.
8. Keep the icon and text aligned centrally using flex layout.

### Required icon behavior
1. Use a decorative spark or star style SVG icon.
2. Keep the icon light gray or off white by default.
3. Add a subtle flicker animation to the icon in the default state.
4. On hover, brighten the icon to white.
5. On hover, add glow using drop shadow based on the highlight color.
6. On focus, keep the icon animation active with slightly adjusted timing.

### Required text behavior
1. Split each displayed word into individual letter spans.
2. Animate each letter with a subtle staggered glow flicker in the default state.
3. Use increasing animation delays for successive letters.
4. Keep the letters dim white by default and brighten during animation peaks.
5. On focus, animate the first word out and the second word in after a short delay.
6. Keep both text layers stacked in the same position so the word swap feels seamless.
7. During the focus transition, make the letters briefly enlarge, blur, and glow.

### Required highlight behavior
1. Use a pseudo element behind or around the button to create a soft outer frame and depth layer.
2. Use another pseudo element on the button surface to create a vertical or top weighted neon highlight wash.
3. Keep the highlight hue configurable with a CSS variable.
4. On hover, increase the border brightness and reveal the surface highlight.
5. On focus, further intensify the highlight effect.
6. On active, make the highlight brightest and the background slightly tinted toward the accent hue.

### Required interaction behavior
1. On hover, brighten the border and highlight overlays.
2. On hover, stop the icon flicker and replace it with a stronger glow.
3. On focus, trigger the text morph from Generate to Generating.
4. On focus, animate letters with a bloom or blur burst before settling.
5. On active, increase highlight intensity and slightly tint the dark background.
6. On active, stop the default letter idle animation and replace it with a crisp illuminated state.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use pseudo elements for layered highlight and depth effects.
4. Use individual span elements per letter to allow staggered timing.
5. Use two overlapping text layers to morph between words on focus.
6. Keep the component premium, futuristic, and highly interactive.

### Code fingerprint
```html
<div class="btn-wrapper">
  <button class="btn">
    <svg class="btn-svg"></svg>
    <div class="txt-wrapper">
      <div class="txt-1">
        <span class="btn-letter">G</span>
      </div>
      <div class="txt-2">
        <span class="btn-letter">G</span>
      </div>
    </div>
  </button>
</div>
```

```css
.btn {
  --border-radius: 24px;
  --padding: 4px;
  --transition: 0.4s;
  --button-color: #101010;
  --highlight-color-hue: 210deg;
}

.btn:before {
  content: "";
  position: absolute;
}

.btn:after {
  content: "";
  position: absolute;
  opacity: 0;
}

.btn-letter {
  animation: letter-anim 2s ease-in-out infinite;
}

.btn-svg {
  animation: flicker 2s linear infinite;
}

.btn:focus .txt-1 {
  animation: opacity-anim 0.3s ease-in-out forwards;
  animation-delay: 1s;
}

.btn:focus .txt-2 {
  animation: opacity-anim 0.3s ease-in-out reverse forwards;
  animation-delay: 1s;
}
```

### Search keywords
futuristic glow button, generate button animation, morphing text button, neon highlight button, glossy dark button, letter by letter glow button, spark icon button, focus text swap button, premium interactive cta
