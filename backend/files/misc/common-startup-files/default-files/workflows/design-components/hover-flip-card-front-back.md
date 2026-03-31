# Create hover flip card front and back
WORKFLOW ==> hover-flip-card-front-back

## Visual identity
A pure HTML and CSS interactive flip card with a soft 3D perspective effect. The card has a front face and a back face, both with rounded corners, coral tinted borders, soft shadows, and warm pastel gradient backgrounds. On hover, the card smoothly rotates around the Y axis to reveal the back side.

## Workflow description
Create a pure HTML and CSS flip card component using a perspective outer wrapper, an inner rotating panel, and two card faces that swap visibility through a 3D Y axis rotation on hover.

### Required structure
1. Use an outer container element with the class `flip-card`.
2. Place one inner rotating element inside it with the class `flip-card-inner`.
3. Add two child face elements inside the inner element using the classes `flip-card-front` and `flip-card-back`.
4. Place text content inside both faces.
5. Add a heading element with the class `title` inside each face.
6. Use a short secondary text line below the title on each side.
7. Keep the markup minimal and symmetrical.

### Required layout
1. Give the outer card a fixed size around `190px` wide and `254px` high.
2. Apply `perspective: 1000px` to the outer wrapper.
3. Keep the component compact and vertically oriented.
4. Make the inner rotating element fill the full width and height.
5. Position the front and back faces absolutely so they overlap perfectly.

### Required outer wrapper styling
1. Use a transparent background on the outer wrapper.
2. Apply a generic sans serif font family.
3. Keep the wrapper dedicated to perspective only.
4. Do not place visual decoration directly on the outer wrapper.

### Required inner rotation styling
1. Style the inner element with `position: relative`.
2. Make it fill the full size of the outer wrapper.
3. Center face content with text alignment centered.
4. Use `transform-style: preserve-3d`.
5. Add a smooth transform transition around `0.8s`.
6. Rotate the inner element on hover of the outer wrapper.
7. Use `rotateY(180deg)` for the flip interaction.

### Required face styling
1. Style both faces together where possible.
2. Add a soft box shadow for depth.
3. Use rounded corners around `1rem`.
4. Add a `1px` solid coral border.
5. Make each face a flex container.
6. Center content vertically.
7. Stack content in a column.
8. Make each face fill the full width and height of the card.
9. Hide the reverse side using `backface-visibility: hidden`.
10. Support both standard and webkit backface visibility.

### Required front face styling
1. Use a warm coral and bisque gradient background.
2. Keep the text color coral.
3. Make the front face the default visible side.
4. Use a playful soft pastel visual style.

### Required back face styling
1. Use a stronger coral tinted gradient background than the front face.
2. Keep the text color white.
3. Rotate the back face by `180deg` so it becomes readable after the flip.
4. Preserve the same rounded shape and shadow as the front face.

### Required text styling
1. Style the `.title` as large, bold, and centered.
2. Use a font size around `1.5em`.
3. Use a heavy font weight around `900`.
4. Remove default margin from the title.
5. Keep the secondary text simple and centered.
6. Use short labels such as `FLIP CARD`, `Hover Me`, `BACK`, and `Leave Me`.

### Required hover behavior
1. Trigger the interaction from hovering the `.flip-card` element.
2. On hover, rotate the `.flip-card-inner` element by `180deg` on the Y axis.
3. Keep the animation smooth and clean.
4. Ensure the front disappears and the back appears naturally through backface visibility.

### Technical implementation notes
1. Use plain HTML and CSS only.
2. Do not use JavaScript.
3. Keep the class names exactly `flip-card`, `flip-card-inner`, `flip-card-front`, `flip-card-back`, and `title`.
4. Use 3D transform techniques rather than swapping display states.
5. Keep the component reusable for profile cards, product cards, reveal cards, or educational flash cards.

### Code fingerprint
- outer perspective wrapper with class `flip-card`
- inner rotating element with class `flip-card-inner`
- front and back faces using `flip-card-front` and `flip-card-back`
- hover on the outer wrapper rotates the inner element with `rotateY(180deg)`
- both faces use `backface-visibility: hidden`
- back face is pre rotated with `rotateY(180deg)`
- both faces share rounded corners, border, and shadow
- front uses a warm pastel coral gradient
- back uses a deeper coral gradient
- centered title text with class `title`

### Search keywords
flip card hover effect, css 3d flip card, front back reveal card, rotateY hover card, pastel coral flip card, pure css flash card, perspective flip panel, interactive double sided card
