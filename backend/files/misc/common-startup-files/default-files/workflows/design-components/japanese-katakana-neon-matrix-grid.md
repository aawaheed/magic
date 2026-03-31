# Create japanese katakana neon matrix grid
WORKFLOW ==> japanese-katakana-neon-matrix-grid

## Visual identity
A pure HTML and CSS full screen matrix style character field made from a dense grid of Japanese katakana glyphs on a very dark background. The symbols glow in cool blue tones by default, while selected characters pulse independently through brighter cyan, pink, and white highlights. The result feels like a futuristic cyberpunk terminal wall or holographic code surface.

## Workflow description
Create a pure HTML and CSS neon matrix grid using a full screen CSS grid container filled with individual span elements containing katakana characters, where staggered nth child selectors apply smooth glowing pulse animations to scattered symbols across the field.

### Required structure
1. Use one outer container element with the class `jp-matrix`.
2. Fill the container with many inline child elements using the `span` tag.
3. Put one katakana character inside each span.
4. Use enough spans to create a dense screen filling field.
5. Repeat characters as needed to fill the layout.
6. Keep the markup flat with no nested rows or columns.

### Required layout
1. Make the matrix container fill the available width and height.
2. Use a CSS grid layout.
3. Define columns with `repeat(auto-fill, minmax(40px, 1fr))` or a very similar responsive pattern.
4. Set the auto row height to around `40px`.
5. Use a minimum size around `1920px` wide and `1080px` high.
6. Center the grid content using `justify-content: center` and `align-content: center`.
7. Hide overflow so the field stays visually contained.

### Required base styling
1. Use a very dark near black background such as `#05050a`.
2. Use a monospace font such as `Courier New`.
3. Set the base font size around `32px`.
4. Use a cool translucent blue as the default character color.
5. Keep the overall appearance like a digital code wall.

### Required character styling
1. Style direct child spans of `.jp-matrix`.
2. Center the glyph text horizontally.
3. Use a soft blue text glow with `text-shadow`.
4. Prevent character selection using `user-select: none`.
5. Add smooth transitions for color and text shadow changes.
6. Keep line height compact around `1`.

### Required animation behavior
1. Create a keyframes animation named `smooth-pulse`.
2. At the start and end, use the default dim blue color and soft glow.
3. Around one phase of the animation, brighten the glyph to vivid cyan or light blue.
4. In another phase, shift the glyph to bright pink.
5. In another phase, brighten the glyph fully to white with a stronger glow.
6. Keep the animation smooth and organic.
7. Use `ease-in-out` timing.
8. Use infinite looping.

### Required stagger pattern behavior
1. Use multiple `nth-child` selectors to scatter animations across the field.
2. Give different selector groups different durations.
3. Give different selector groups different delays.
4. Allow some groups to change only animation timing while others also brighten the base tone.
5. Keep the pulsing pattern irregular so the field feels alive and non repetitive.
6. Use several selector formulas such as `19n + 2`, `29n + 1`, `11n`, `37n + 10`, `41n + 1`, and other similar patterns.

### Required color progression
1. Default state should be translucent blue.
2. First highlight state should become brighter cyan or icy blue.
3. Second highlight state should shift into pink.
4. Final highlight state should become white with the strongest glow.
5. Return smoothly back to the dim blue base state.

### Required content behavior
1. Use Japanese katakana characters throughout the grid.
2. Repeat characters to build a large visual texture.
3. Prefer characters such as `ア`, `イ`, `ウ`, `エ`, `オ`, `カ`, `キ`, `ク`, `ケ`, `コ`, and similar sets.
4. Keep the content decorative rather than semantic.

### Technical implementation notes
1. Use plain HTML and CSS only.
2. Do not use JavaScript.
3. Keep the class name exactly `jp-matrix`.
4. Use direct child span selectors for animation targeting.
5. Keep the component reusable as a hero background, cyberpunk panel, loading scene, or animated decorative surface.

### Code fingerprint
- outer container with class `jp-matrix`
- full field built from many direct child `span` elements
- CSS grid with `auto-fill` and `minmax(40px, 1fr)`
- minimum viewport like dimensions around `1920px` by `1080px`
- default translucent blue katakana glyphs on a dark background
- scattered `nth-child` rules assign staggered `smooth-pulse` animations
- animated colors progress through blue, cyan, pink, and white
- glowing text shadows intensify during pulse peaks
- no JavaScript and no nested row wrappers

### Search keywords
katakana matrix grid, neon japanese character wall, cyberpunk glyph background, animated code grid, glowing matrix spans, pure css character matrix, blue pink white pulse grid, futuristic katakana background
