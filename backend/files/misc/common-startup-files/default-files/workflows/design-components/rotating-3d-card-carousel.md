# Create rotating 3d card carousel
WORKFLOW ==> rotating-3d-card-carousel

## Visual identity
A pure HTML and CSS 3D carousel made from multiple vertically oriented rectangular cards arranged in a circular ring. The full ring rotates continuously in 3D space with a slight upward tilt, creating a futuristic holographic showcase effect. Each card has a soft neon tinted border, rounded corners, and a glowing radial gradient fill based on a unique RGB color.

## Workflow description
Create a pure HTML and CSS rotating 3D card carousel using a perspective container, a preserve 3D inner wrapper, and multiple cards distributed evenly around a circular axis with continuous rotation.

### Required structure
1. Use an outer container element with the class `wrapper`.
2. Place one inner rotating element inside it with the class `inner`.
3. Add multiple child elements inside the inner element using the class `card`.
4. Use a CSS custom property `--quantity` on the inner element to define the number of cards.
5. Use a CSS custom property `--index` on each card to define its position in the ring.
6. Use a CSS custom property `--color-card` on each card to define its RGB accent color.
7. Place one child element with the class `img` inside each card.
8. Use ten cards by default.

### Required layout
1. Make the outer wrapper fill the available width and height.
2. Center the carousel horizontally and vertically using flexbox.
3. Keep the wrapper positioned relatively.
4. Hide overflow so the rotating ring stays visually contained.
5. Position the inner element absolutely near the upper middle area using top around `25%`.
6. Give the inner element a fixed width around `100px` and height around `150px`.

### Required 3d setup
1. Define CSS custom properties on the inner element for width, height, translateZ, rotateX, and perspective.
2. Use `transform-style: preserve-3d` on the inner element.
3. Use `transform: perspective(var(--perspective))` as the base transform.
4. Tilt the full carousel using a negative X rotation around `-15deg`.
5. Push each card outward in 3D space using `translateZ`.
6. Distribute the cards evenly around the Y axis using `rotateY(calc((360deg / var(--quantity)) * var(--index)))`.

### Required animation behavior
1. Animate the inner element continuously.
2. Use a keyframes animation named `rotating`.
3. Start from `rotateY(0)`.
4. End at `rotateY(1turn)`.
5. Preserve the same perspective and X tilt throughout the animation.
6. Use a linear infinite animation.
7. Use a duration around `20s`.

### Required card styling
1. Position each card absolutely within the inner element.
2. Make each card fill the full size of the inner element using `inset: 0`.
3. Add a border using the RGB value from `--color-card`.
4. Use rounded corners around `12px`.
5. Hide overflow inside the card.
6. Keep the card background transparent except for the inner glow content.

### Required inner panel styling
1. Use an inner child element with the class `img`.
2. Make it fill the full width and height of the card.
3. Use `object-fit: cover`.
4. Create the visible color effect with a radial gradient background.
5. Use the card RGB color in multiple opacity levels.
6. Start with a soft transparent center glow.
7. Increase the color intensity toward the outer edge.
8. End with a more saturated outer glow.

### Technical implementation notes
1. Use plain HTML and CSS only.
2. Do not use JavaScript.
3. Keep the class names exactly `wrapper`, `inner`, `card`, and `img`.
4. Use CSS custom properties exactly for quantity, index, color, size, perspective, and tilt.
5. Keep the component reusable for futuristic galleries, feature displays, or decorative hero sections.

### Code fingerprint
- outer wrapper with class `wrapper`
- rotating inner element with class `inner`
- inner element uses `--quantity`
- cards use `--index` and `--color-card`
- cards positioned in a 3D ring with `rotateY` and `translateZ`
- inner element uses `transform-style: preserve-3d`
- continuous `rotating` keyframes animation rotates the full ring
- wrapper centers the component and hides overflow
- each card contains a child element with class `img`
- `img` uses a radial gradient based on the card RGB color

### Search keywords
3d card carousel, rotating css card ring, perspective card spinner, pure css 3d carousel, neon card cylinder, rotating holographic cards, preserve 3d card animation, circular card showcase
