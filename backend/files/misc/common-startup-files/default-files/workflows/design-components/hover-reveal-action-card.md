# Create hover reveal action card
WORKFLOW ==> hover-reveal-action-card

## Visual identity
A pure HTML and CSS minimal content card with rounded corners, a light neutral background, a subtle border, and a hidden call to action button that slides upward into view on hover. The design feels clean, modern, and product focused, with centered text content and a soft blue accent used for the interactive button and hover border state.

## Workflow description
Create a pure HTML and CSS content card using a rounded bordered panel, centered text details, and a bottom anchored action button that is initially hidden below the card and animates upward into view when the card is hovered.

### Required structure
1. Use a single outer container element with the class `card`.
2. Inside the card, add a content wrapper with the class `card-details`.
3. Inside the content wrapper, add a title element with the class `text-title`.
4. Add a secondary text element with the class `text-body` below the title.
5. Add one action button as a sibling of the content wrapper using the class `card-button`.
6. Keep the markup simple and compact.

### Required layout
1. Give the card a fixed size around `190px` wide and `254px` high.
2. Use a relatively positioned card so the button can be positioned absolutely inside it.
3. Add internal padding around `1.8rem`.
4. Allow overflow to remain visible so the button can extend beyond the card boundary.
5. Keep the card vertically oriented and centered around its content.

### Required card styling
1. Use a light neutral background such as `#f5f5f5`.
2. Add rounded corners around `20px`.
3. Add a soft neutral border around `2px`.
4. Use a smooth transition around `0.5s` for hover changes.
5. Keep the base style simple and clean.

### Required content styling
1. Style the `card-details` area to fill the full card height.
2. Use grid layout for the content wrapper.
3. Center the content using `place-content: center`.
4. Add a small gap between the title and body text.
5. Keep the main text color black.

### Required title styling
1. Style the `.text-title` as bold and prominent.
2. Use a font size around `1.5em`.
3. Make the title the strongest visual text element.

### Required body text styling
1. Style the `.text-body` with a muted gray tone.
2. Keep the body text readable but visually secondary.
3. Use text similar to supporting details or description copy.

### Required action button styling
1. Use an element with the class `card-button`.
2. Position the button absolutely near the bottom center of the card.
3. Center it horizontally using `left: 50%` and translate.
4. Give the button a width around `60%`.
5. Use rounded corners around `1rem`.
6. Remove the default border.
7. Use a bright blue background.
8. Use white text.
9. Use comfortable button padding around `.5rem 1rem`.
10. Start the button visually below the card using a downward translate value.
11. Set the button opacity to `0` initially.
12. Add a smooth transition around `0.3s`.

### Required hover behavior
1. Trigger the interaction from hovering the `.card` element.
2. On hover, change the card border color to the same bright blue as the button.
3. On hover, add a soft elevated box shadow.
4. On hover, animate the button upward so it becomes partially attached to the bottom edge of the card.
5. On hover, change the button opacity from `0` to `1`.
6. Keep the hover transition clean and product card like.

### Technical implementation notes
1. Use plain HTML and CSS only.
2. Do not use JavaScript.
3. Keep the class names exactly `card`, `card-details`, `card-button`, `text-title`, and `text-body`.
4. Use absolute positioning and transform for the button reveal effect.
5. Keep the component reusable for feature cards, product cards, pricing highlights, or call to action panels.

### Code fingerprint
- outer card with class `card`
- centered content wrapper with class `card-details`
- title with class `text-title`
- body copy with class `text-body`
- bottom action button with class `card-button`
- button starts hidden below the card using translate
- card hover changes border color and adds shadow
- button slides upward and fades into view on hover
- overflow remains visible so the button can extend outside the card

### Search keywords
hover reveal card button, css action card, product card with slide up button, minimal info card hover, pure css call to action card, bordered card with hover button, clean content card, animated button reveal card
