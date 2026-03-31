# Create overlapping glassmorphism icon card stack
WORKFLOW ==> overlapping-glassmorphism-icon-card-stack

## Visual identity
A pure HTML and CSS glassmorphism card stack made from three semi transparent rectangular cards overlapping horizontally. Each card has a frosted glass appearance with subtle blur, a faint white border, soft shadow, rounded corners, and a slight individual rotation. On hover, the cards smoothly straighten and spread apart. Each card contains a centered white SVG icon and a bottom label bar rendered from a data attribute.

## Workflow description
Create a pure HTML and CSS overlapping glass card component using translucent rotated cards with centered SVG icons, bottom label bars, and a hover interaction that resets rotation and increases spacing.

### Required structure
1. Use an outer container element with the class `container`.
2. Place multiple child card elements inside the container using the class `glass`.
3. Use exactly three cards by default.
4. Add a `data-text` attribute to each card containing its label text.
5. Add an inline CSS custom property `--r` on each card to control its initial rotation angle.
6. Place one SVG icon inside each card.
7. Use short labels such as `Github`, `Code`, and `Earn`.

### Required layout
1. Center the full component using flexbox.
2. Arrange the cards in a horizontal row.
3. Slightly overlap the cards using negative horizontal margins.
4. Give each card a fixed size around `180px` wide and `200px` high.
5. Keep the container positioned relatively.

### Required card styling
1. Style each card with a translucent gradient background.
2. Apply a frosted glass look using `backdrop-filter: blur(10px)`.
3. Add a subtle semi transparent white border.
4. Add a soft dark box shadow.
5. Use rounded corners around `10px`.
6. Center the icon horizontally and vertically.
7. Rotate each card using `transform: rotate(calc(var(--r) * 1deg))`.
8. Add a smooth transition around `0.5s`.

### Required hover behavior
1. Trigger the hover effect from the parent container.
2. On hover, reset all card rotations to `0deg`.
3. On hover, spread the cards apart horizontally.
4. Replace the overlapping negative margins with positive spacing on hover.
5. Keep the movement smooth and visually balanced.

### Required label behavior
1. Create the label using a pseudo element on each card.
2. Use `content: attr(data-text)` to render the label.
3. Position the label bar at the bottom of the card.
4. Make the label span the full width of the card.
5. Give the label a subtle translucent background.
6. Center the label text horizontally and vertically.
7. Use white text for the label.

### Required icon styling
1. Keep the SVG icon centered inside each card.
2. Use white fill color for the icon.
3. Size the icon around `2.5em`.
4. Keep the icon visually simple and bold.

### Technical implementation notes
1. Use plain HTML and CSS only.
2. Do not use JavaScript.
3. Keep the class names exactly `container` and `glass`.
4. Use the `data-text` attribute and `--r` custom property exactly as part of the component pattern.
5. Keep the component reusable for social cards, feature cards, or category cards.

### Code fingerprint
- outer wrapper with class `container`
- multiple child cards with class `glass`
- each card has a `data-text` attribute
- each card uses inline `--r` custom rotation
- cards overlap using negative horizontal margins
- cards use translucent gradient, blur, border, and shadow for the glass effect
- hover on the container resets rotation and spreads the cards apart
- card label is rendered with `:before` and `attr(data-text)`
- centered white SVG icon inside each card

### Search keywords
glassmorphism card stack, overlapping glass cards, frosted glass icon cards, rotated glass panels, hover spread glass cards, translucent icon card row, pure css glass cards, stacked glassmorphism cards
