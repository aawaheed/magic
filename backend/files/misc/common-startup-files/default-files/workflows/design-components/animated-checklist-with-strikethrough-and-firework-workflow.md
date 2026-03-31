# Create animated checklist with strikethrough and firework effect
WORKFLOW ==> animated-checklist-with-strikethrough-and-firework

## Visual identity
A pure HTML and CSS checklist card with a clean white panel, soft shadow, and vertically stacked grocery style items. Each item uses a custom animated checkbox that draws its own checkmark when selected. When an item is checked, the text shifts slightly, fades to a disabled tone, gains a sliding strikethrough line, and triggers a tiny firework burst near the label.

## Workflow description
Create a pure HTML and CSS checklist card with custom animated checkboxes, label strike animation, and a small celebratory firework effect on check.

### Required structure
1. Use a single checklist container element.
2. Inside it, alternate checkbox inputs and label elements.
3. Give each checkbox a unique id.
4. Link each label to its corresponding checkbox using the for attribute.
5. Arrange the content as a two column grid with checkbox controls on the left and labels on the right.
6. Include multiple checklist items such as Bread, Cheese, and Coffee.

### Required styling
1. Define reusable CSS variables for background, text color, check accent color, disabled text color, width, height, and border radius.
2. Style the checklist as a small white card with rounded corners.
3. Add a soft drop shadow to the card.
4. Use padding that creates generous inner spacing.
5. Use CSS grid layout with a narrow control column and an auto label column.
6. Center the grid content neatly inside the card.
7. Keep the labels compact and readable.
8. Use a neutral dark text color for unchecked items.

### Required checkbox behavior
1. Hide the native checkbox styling using appearance none.
2. Build the visible checkmark using the checkbox before and after pseudo elements.
3. Keep the pseudo elements as short accent lines by default.
4. On checked state, animate the two lines so they rotate and form a tick mark.
5. Use separate keyframes for the two checkmark strokes.
6. Keep the check accent in a vivid purple or similar color.

### Required label behavior
1. Place each label beside its checkbox.
2. Add a small accent line before the label text in the default state.
3. Add a small decorative dot using the label after pseudo element.
4. On checked state, change the label color to a disabled gray tone.
5. On checked state, animate the label slightly sideways to create a completed motion effect.
6. On checked state, animate the accent line so it expands across the label like a strikethrough.

### Required celebration behavior
1. On checked state, animate the label after pseudo element as a small firework burst.
2. Use multiple box shadow particles radiating outward.
3. Fade the firework out as it expands.
4. Trigger it shortly after the check event.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Use adjacent sibling selectors so each checkbox controls its paired label.
4. Use keyframes for the checkmark drawing, label movement, strikethrough slice, and firework burst.
5. Keep the component suitable for to do lists, shopping lists, or playful task completion UIs.

### Code fingerprint
```html
<div id="checklist">
  <input checked value="1" name="r" type="checkbox" id="01">
  <label for="01">Bread</label>
  <input value="2" name="r" type="checkbox" id="02">
  <label for="02">Cheese</label>
  <input value="3" name="r" type="checkbox" id="03">
  <label for="03">Coffee</label>
</div>
```

```css
#checklist {
  --background: #fff;
  --text: #414856;
  --check: #4f29f0;
  --disabled: #c3c8de;
  display: grid;
  grid-template-columns: 30px auto;
}

#checklist input[type="checkbox"]:checked:before {
  animation: check-01 0.4s ease forwards;
}

#checklist input[type="checkbox"]:checked:after {
  animation: check-02 0.4s ease forwards;
}

#checklist input[type="checkbox"]:checked + label:before {
  animation: slice 0.4s ease forwards;
}

#checklist input[type="checkbox"]:checked + label:after {
  animation: firework 0.5s ease forwards 0.1s;
}
```

### Search keywords
animated checklist, custom checkbox list, strikethrough task animation, firework checkbox effect, shopping list ui, pure css todo checklist, checkmark draw animation, playful checklist card
