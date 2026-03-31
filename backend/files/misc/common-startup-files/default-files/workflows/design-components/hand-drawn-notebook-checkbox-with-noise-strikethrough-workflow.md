# Create hand drawn notebook checkbox with noise strikethrough
WORKFLOW ==> hand-drawn-notebook-checkbox-with-noise-strikethrough

## Visual identity
A pure HTML and CSS notebook style checkbox with a rough hand drawn aesthetic. The control uses a monospace typeface, a noisy sketch filter, a rounded checkbox that fills like ink, and a hand drawn strike line that cuts through the label when checked. The result feels like a scribbled to do item in a paper notebook.

## Workflow description
Create a pure HTML and CSS hand drawn checkbox using an SVG noise filter, a sketched checkbox mark animation, and a rough strikethrough line over the text.

### Required structure
1. Use a label element as the clickable wrapper.
2. Place a checkbox input inside the label.
3. Add a span element for the custom checkbox mark.
4. Add a span element for the text content.
5. Inside the text span, add a nested span for the visible label text.
6. Also inside the text span, add an SVG element for the hand drawn cut line.
7. Add a separate hidden SVG filter definition in the markup for the hand drawn noise effect.

### Required styling
1. Style the wrapper as an inline flex row aligned vertically in the center.
2. Add left padding so there is room for the custom checkbox mark.
3. Use a monospace notebook style font such as Courier New.
4. Use a relatively large bold text size around 1.5rem.
5. Apply the hand drawn SVG filter to the text and checkbox elements.
6. Keep the component looking rough, sketchy, and analog.

### Required checkbox behavior
1. Hide the native checkbox input visually.
2. Position the custom checkbox mark to the left of the text.
3. Style the mark as a rounded square around 1em by 1em.
4. Use a dark semi transparent border on the mark.
5. Fill the default mark with a faint radial ink like center.
6. On checked state, animate the fill so it grows like ink spreading.
7. On unchecked state, animate the mark back out using a reverse unmark animation.

### Required text behavior
1. Keep the text fully visible by default.
2. Add a rough horizontal cut line SVG positioned across the lower middle of the text.
3. Keep the cut line hidden initially using scaleX zero.
4. On checked state, animate the cut line from left to right.
5. On checked state, fade the text color to a muted gray.

### Required filter behavior
1. Define an SVG filter named handDrawnNoise.
2. Use fractal noise turbulence and displacement map primitives.
3. Apply the filter to the text, input, and custom mark elements where appropriate.
4. Keep the distortion subtle enough to suggest a hand drawn look.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use the hidden checkbox plus sibling selector pattern.
4. Use keyframes for mark and unmark animations.
5. Use an SVG filter to create the rough notebook sketch effect.
6. Keep the component suitable for to do lists, notes, or creative journal interfaces.

### Code fingerprint
```html
<label class="notebook-checkbox">
  <input type="checkbox" />
  <span class="checkmark"></span>
  <span class="text">
    <span class="text-content">Lorem Ipsum</span>
    <svg preserveAspectRatio="none" viewBox="0 0 400 20" class="cut-line">
      <path d="M0,10 H400"></path>
    </svg>
  </span>
</label>

<svg height="0" width="0">
  <filter id="handDrawnNoise">
    <feTurbulence result="noise" numOctaves="8" baseFrequency="0.1" type="fractalNoise"></feTurbulence>
    <feDisplacementMap yChannelSelector="G" xChannelSelector="R" scale="3" in2="noise" in="SourceGraphic"></feDisplacementMap>
  </filter>
</svg>
```

```css
.notebook-checkbox {
  position: relative;
  display: inline-flex;
  align-items: center;
  padding-left: 2em;
  font-family: "Courier New", monospace;
}

.notebook-checkbox .checkmark {
  position: absolute;
  left: 0;
  height: 1em;
  width: 1em;
  border-radius: 10px;
  border: 3px solid #33333366;
  filter: url(#handDrawnNoise);
  background: radial-gradient(#333333f1 65%, #33333300 70%);
}

.notebook-checkbox input:checked ~ .checkmark {
  animation: mark 0.3s forwards;
}

.notebook-checkbox input:checked ~ .text .cut-line {
  transform: scaleX(1);
}
```

### Search keywords
hand drawn checkbox, notebook todo checkbox, noisy sketch checkbox, rough strikethrough label, svg noise filter checkbox, scribble style checklist, journal checkbox ui, pure css hand drawn task item
