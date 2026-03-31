# Create falling matrix rain columns
WORKFLOW ==> falling-matrix-rain-columns

## Visual identity
A pure HTML and CSS matrix rain effect made from multiple vertical character streams falling over a black background. Each stream is a narrow glowing column of katakana, Latin letters, digits, and symbols rendered with a bright white leading edge that fades through neon green into darkness. The overall effect feels like a classic digital rain wall with staggered speeds, randomized content variations, and multiple repeating pattern panels placed side by side.

## Workflow description
Create a pure HTML and CSS falling matrix rain scene using a flex container with several repeated pattern panels, each containing many absolutely positioned animated character columns whose visible glyph streams are rendered with pseudo elements and vertical writing mode.

### Required structure
1. Use one outer container element with the class `matrix-container`.
2. Inside it, place multiple repeated panel elements with the class `matrix-pattern`.
3. Use several pattern panels side by side to create a wide continuous scene.
4. Inside each pattern panel, place many empty child elements with the class `matrix-column`.
5. Use around forty columns per pattern panel by default.
6. Do not place visible text directly inside the `.matrix-column` elements.
7. Render the actual character streams through the `:before` pseudo element.

### Required layout
1. Make the outer container fill the available width and height.
2. Use a solid black background.
3. Use `display: flex` on the outer container.
4. Keep each pattern panel relatively positioned.
5. Give each pattern panel a fixed width around `1000px` and full available height.
6. Prevent the panels from shrinking using `flex-shrink: 0`.
7. Keep the scene horizontally repeatable by placing multiple pattern panels adjacent to one another.

### Required column styling
1. Position each `.matrix-column` absolutely inside its pattern panel.
2. Start each column above the visible area with `top: -100%` or a very similar value.
3. Make each column narrow, around `20px` wide.
4. Make each column span the full available panel height.
5. Use a bold monospace friendly look.
6. Use font size around `16px` and line height around `18px`.
7. Prevent wrapping using `white-space: nowrap`.
8. Animate each column with a shared falling keyframes animation.

### Required pseudo element behavior
1. Use `.matrix-column:before` to render the visible glyph stream.
2. Place the pseudo element absolutely at the top left of its column.
3. Use `writing-mode: vertical-lr` to make the characters flow vertically.
4. Use `background-clip: text` and transparent text fill so the gradient colors the glyphs.
5. Apply a vertical gradient that starts bright white at the leading edge.
6. Fade the white into neon green.
7. Continue through darker greens lower in the stream.
8. End in transparency near the tail of the column.
9. Improve text rendering with antialiasing and legibility settings.

### Required content behavior
1. Use katakana characters mixed with uppercase Latin letters and digits.
2. Define one default content string for the pseudo elements.
3. Override the content string for odd columns.
4. Override the content string for even columns.
5. Add additional content variations for selectors such as `3n`, `4n`, and `5n`.
6. Include alternative streams containing reversed katakana sequences, digits, and symbol heavy strings.
7. Keep the streams decorative and dense rather than semantic.

### Required placement behavior
1. Place each column at a specific horizontal offset using `left` values.
2. Space columns roughly every `25px` across the width of a pattern panel.
3. Use explicit nth child rules to assign the left position of each column.
4. Continue until the panel width is filled.

### Required animation behavior
1. Create a keyframes animation named `fall`.
2. At the start, keep the stream slightly above the visible region.
3. At the end, move the stream well below the visible region.
4. Fade opacity from visible to invisible during the fall.
5. Use linear timing.
6. Loop the animation infinitely.
7. Give each column a different animation duration.
8. Give each column a different negative animation delay so the scene starts mid cycle.
9. Keep the timing staggered and irregular to avoid synchronized movement.

### Required color behavior
1. Use white for the brightest head of the stream.
2. Transition into vivid green.
3. Fade into darker greens and semi transparent green lower in the trail.
4. End with full transparency.
5. Keep the scene strongly associated with classic matrix rain visuals.

### Required responsive behavior
1. Add a media query around `768px` width.
2. In that breakpoint, slightly reduce the column width, font size, and line height.
3. Add another media query around `480px` width.
4. Reduce the column width, font size, and line height further for small screens.
5. Preserve the same visual style while scaling density appropriately.

### Technical implementation notes
1. Use plain HTML and CSS only.
2. Do not use JavaScript.
3. Keep the class names exactly `matrix-container`, `matrix-pattern`, and `matrix-column`.
4. Use pseudo elements for the actual glyph strings rather than text nodes.
5. Use many explicit nth child rules for placement, delays, and durations.
6. Keep the component reusable as a hero background, cyberpunk scene, animated backdrop, or terminal themed visual effect.

### Code fingerprint
- outer wrapper with class `matrix-container`
- multiple side by side repeated panels with class `matrix-pattern`
- many empty child elements with class `matrix-column`
- columns use `:before` to render the visible glyph streams
- `writing-mode: vertical-lr` creates vertical text flow
- gradient clipped text creates white to green stream coloring
- explicit nth child rules set left offsets, delays, and durations
- odd, even, `3n`, `4n`, and `5n` selectors change glyph content strings
- shared `fall` keyframes move each stream downward and fade it out
- responsive media queries reduce column size on smaller screens

### Search keywords
matrix rain columns, falling katakana streams, digital rain background, css matrix effect, vertical character rain, neon green code rain, pseudo element matrix columns, cyberpunk falling glyph wall
