# Create tilted 3d glass profile card
WORKFLOW ==> tilted-3d-glass-profile-card

## Visual identity
A pure HTML and CSS 3D profile style card with a bright green gradient base, a translucent glass overlay, layered circular logo elements, floating social buttons, and a tilted hover interaction. The card feels glossy, futuristic, and dimensional, using perspective, preserve 3D transforms, soft shadows, rounded corners, and depth separation between content layers.

## Workflow description
Create a pure HTML and CSS 3D glass card using a perspective parent, a rounded gradient card body, a translucent inset glass layer, layered circular logo elements, content text, social icon buttons, and a hover effect that tilts the card and lifts selected child elements forward in 3D space.

### Required structure
1. Use an outer container element with the class `parent`.
2. Place one main card element inside it with the class `card`.
3. Add a top decorative section inside the card with the class `logo`.
4. Inside the logo section, add five layered circular elements using the class `circle` plus modifier classes `circle1` through `circle5`.
5. Place one SVG icon inside `circle5`.
6. Add one inset translucent layer inside the card with the class `glass`.
7. Add one content section with the class `content`.
8. Inside the content section, add a title element with the class `title` and a description element with the class `text`.
9. Add a bottom action row with the class `bottom`.
10. Inside the bottom row, add a social button group with the class `social-buttons-container`.
11. Place three circular icon buttons inside that group using the class `social-button`.
12. Add a right aligned action area with the class `view-more`.
13. Inside the action area, add a text button with the class `view-more-button` and a small arrow SVG.

### Required layout
1. Give the parent a fixed size around `290px` wide and `300px` high.
2. Apply `perspective: 1000px` to the parent.
3. Make the card fill the full height of the parent.
4. Use very large rounded corners around `50px` on the main card.
5. Keep the decorative circles positioned in the top right area.
6. Keep the text content aligned toward the left middle area.
7. Keep the action row pinned near the bottom with left and right spacing.

### Required main card styling
1. Style the main card with a diagonal green gradient background.
2. Use `transform-style: preserve-3d` on the card.
3. Add a layered shadow that feels soft and elevated.
4. Add a smooth transition around `0.5s`.
5. Keep the card visually glossy and dimensional.

### Required glass overlay styling
1. Add an inset layer with the class `glass` positioned absolutely with small inset spacing.
2. Give it rounded corners slightly larger than the card interior.
3. Make the top right corner more exaggerated with a stronger radius.
4. Use a translucent white gradient background.
5. Move the glass layer forward in 3D space using `translate3d`.
6. Add subtle white edge accents on the left and bottom.
7. Keep the layer visually like a frosted pane floating above the card.

### Required content styling
1. Push the content forward in 3D space slightly more than the glass overlay.
2. Add generous top and side padding.
3. Style the title as bold, dark green, and highly readable.
4. Style the body text as softer green with lower opacity.
5. Keep the content compact and left aligned.

### Required bottom row behavior
1. Place the bottom row absolutely near the lower edge of the card.
2. Use flex layout to separate the social buttons and the view more action.
3. Push the bottom row forward in 3D space.
4. Keep the social buttons on the left and the view more action on the right.

### Required social button styling
1. Use a horizontal group with class `social-buttons-container`.
2. Add three circular buttons with white backgrounds.
3. Give each button a small soft shadow.
4. Center one SVG icon inside each button.
5. Use green icon fill by default.
6. On hover, change the button background to black and the icon fill to white.
7. On active state, change the background to yellow and the icon fill to black.
8. Apply staggered transitions to the first, second, and third buttons so they lift with slight delays.

### Required view more styling
1. Place the `view-more` area on the right side of the bottom row.
2. Align its content horizontally.
3. Use a text button with no visible background.
4. Style the text in bright green and bold small uppercase like UI text.
5. Add a small arrow SVG beside the text.
6. On hover, move the whole action slightly forward in 3D space.

### Required logo decoration styling
1. Position the logo group absolutely in the top right corner.
2. Create five overlapping circular layers using classes `circle1` through `circle5`.
3. Use translucent aqua or green tinted backgrounds for the circles.
4. Add blur or glass like appearance where supported.
5. Increase the Z depth progressively from circle1 to circle5.
6. Decrease the circle size progressively from the back layer to the front layer.
7. Place a white SVG logo in the smallest front circle.
8. Add transition delays so the circles animate in a cascading depth effect.

### Required hover behavior
1. Trigger the interaction from hovering the `.parent` element.
2. On hover, rotate the main card in 3D using `rotate3d(1, 1, 0, 30deg)` or a very similar tilt.
3. Strengthen or shift the card shadow to emphasize elevation.
4. On hover, move the social buttons farther forward in 3D space.
5. On hover, increase the Z translation of circle2 through circle5.
6. Keep the hover animation smooth and layered.
7. Make the design feel like card parts are separating in depth rather than sliding in 2D.

### Technical implementation notes
1. Use plain HTML and CSS only.
2. Do not use JavaScript.
3. Keep the class names exactly `parent`, `card`, `glass`, `content`, `bottom`, `logo`, `circle`, `social-buttons-container`, `social-button`, `view-more`, and `view-more-button`.
4. Use `transform-style: preserve-3d` consistently on the card and key child wrappers.
5. Use `translate3d` to establish visual depth between layers.
6. Keep the component reusable for profile cards, feature cards, product promos, or social link cards.

### Code fingerprint
- outer perspective wrapper with class `parent`
- main rounded gradient element with class `card`
- inset translucent overlay with class `glass`
- top right decorative logo cluster with classes `logo`, `circle1`, `circle2`, `circle3`, `circle4`, and `circle5`
- content section with `title` and `text`
- bottom row with social button cluster and `view-more` action
- social buttons are circular, white, and lift forward on hover with staggered timing
- card tilts in 3D on parent hover
- layered circles increase their Z translation on hover
- multiple child layers use `translate3d` to create depth

### Search keywords
3d glass profile card, tilted gradient card, floating social button card, layered glass ui card, perspective profile card, futuristic promo card, preserve 3d card hover, glossy glass social card
