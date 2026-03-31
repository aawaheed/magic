# Create selectable card checkbox tile with icon and check badge
WORKFLOW ==> selectable-card-checkbox-tile-icon-badge

## Visual identity
A pure HTML and CSS selectable option card built from a hidden checkbox and a styled content tile. The card looks like a rounded white selection tile with a centered icon and label, and when selected it changes accent color, highlights its border, and shows a small circular check badge in the top left corner. The component behaves like a modern choice card for picking tools, categories, or services.

## Workflow description
Create a pure HTML and CSS selectable card component using a hidden checkbox and a styled visual tile, without relying on Tailwind.

### Required structure
1. Use a wrapper container that can hold one or more selectable cards in a flexible row or wrapped layout.
2. Use a label element as the clickable wrapper for each card.
3. Place a checkbox input inside the label.
4. Visually hide the checkbox while keeping it accessible and clickable.
5. Place a visible card element after the checkbox.
6. Inside the card, place:
   - an icon container
   - a text label
7. Use the checkbox checked state to control the visual appearance of the card.

### Required styling
1. Style the outer layout as a flexible row with:
   - wrapping enabled
   - centered alignment
   - small gap between cards
   - responsive width constraints
2. Style each card as a white rounded rectangle with:
   - fixed or semi-fixed width
   - minimum height around 7rem
   - centered content
   - vertical stacking
   - subtle shadow
   - light gray border
   - pointer cursor
   - smooth transitions
3. Prevent text selection on the component if desired.
4. Center the icon and label inside the card.
5. Use a muted gray default text and border color.

### Required checked state behavior
1. When the checkbox is checked:
   - change the card border to a blue accent color
   - change the text color to the same blue accent
   - add a subtle blue tinted shadow or glow
2. Show a small circular badge near the top left corner of the card.
3. The badge should:
   - become visible only on hover or checked state
   - use the same blue accent
   - contain a checkmark
   - be circular
   - animate in with opacity and scale
4. Keep the transition smooth and modern.

### Required hover behavior
1. On hover, highlight the card border with the accent color.
2. On hover, reveal or partially reveal the circular badge.
3. Use small transition durations around 0.2s to 0.3s.

### Icon and label behavior
1. Use a centered icon of medium large size near the top half of the card.
2. Place the label text below the icon.
3. Keep both icon and text centered.
4. Use currentColor or equivalent styling so the icon color changes together with the card text color.

### Technical implementation notes
1. Do not rely on Tailwind utility classes.
2. Use normal semantic HTML and plain CSS classes.
3. Use the checkbox plus adjacent or general sibling selector pattern for checked state styling.
4. Use a pseudo element or dedicated badge element for the circular check indicator.
5. No JavaScript is required.

### Code fingerprint
```html
<label class="select-card">
  <input type="checkbox" class="select-card-checkbox">
  <span class="select-card-tile">
    <span class="select-card-icon"></span>
    <span class="select-card-label">Figma</span>
  </span>
</label>
```

```css
.select-card-checkbox:checked + .select-card-tile {
  border-color: #3b82f6;
  color: #3b82f6;
  box-shadow: 0 8px 24px rgba(59, 130, 246, 0.1);
}

.select-card-tile:before {
  content: "✓";
  opacity: 0;
  transform: scale(0);
}

.select-card:hover .select-card-tile:before,
.select-card-checkbox:checked + .select-card-tile:before {
  opacity: 1;
  transform: scale(1);
}
```

### Search keywords
selectable card checkbox, choice tile card, icon option card, check badge card, modern selection tile, hidden checkbox card ui, blue accent choice card, pure css selectable card
