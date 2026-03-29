# Design Profile Schema
WORKFLOW ==> design-profile-schema

## Purpose
This schema defines a reusable design profile format for frontend generation. It is intended to improve consistency, visual quality, and implementation defaults when creating websites and apps.

## Required sections

### 1. Name
A short human-readable design profile name.

### 2. Summary
A short explanation of the style and intended visual outcome.

### 3. Best use cases
A list of suitable product or website categories.

### 4. Visual identity
- Mood
- Tone
- Density
- Contrast

### 5. Typography
- Heading font
- Body font
- Monospace font
- H1 size
- H2 size
- Body size
- Line height
- Letter spacing

### 6. Color system
- Background
- Background secondary
- Surface
- Surface elevated
- Text primary
- Text secondary
- Accent primary
- Accent secondary
- Border
- Glow
- Shadow

### 7. Spacing and layout
- Max content width
- Section padding
- Card padding
- Grid gap
- Border radius
- Border width

### 8. Components
#### Buttons
- Primary button
- Secondary button
- Hover
- Radius
- Padding

#### Cards
- Background
- Border
- Shadow
- Blur
- Radius

#### Forms
- Input background
- Input border
- Input text
- Input radius
- Focus state

#### Navigation
- Height
- Background
- Border
- Link style
- CTA style

### 9. Motion
- Transition speed
- Easing
- Hover effects
- Scroll effects
- Glow animation
- Parallax

### 10. Imagery direction
- Photography
- Illustration
- 3D
- Backgrounds
- Icons

### 11. Do
List of recommended implementation rules.

### 12. Avoid
List of anti-patterns.

### 13. Hero direction
One short paragraph describing how a homepage hero should feel.

### 14. Implementation notes
Practical CSS and layout guidance.

### 15. Tokens
A machine-friendly token block with fonts, colors, layout, and motion values.

## Suggested token structure

```json
{
  "fonts": {
    "heading": "",
    "body": "",
    "mono": ""
  },
  "colors": {
    "bg": "",
    "bg2": "",
    "surface": "",
    "surface2": "",
    "text": "",
    "muted": "",
    "accent": "",
    "accent2": "",
    "border": "",
    "glow": "",
    "shadow": ""
  },
  "layout": {
    "maxWidth": "",
    "sectionPadding": "",
    "cardPadding": "",
    "gap": "",
    "radius": "",
    "borderWidth": ""
  },
  "motion": {
    "duration": "",
    "easing": ""
  }
}
```

## Naming convention
Use titles like:
- Design Profile; Dark Futuristic AI
- Design Profile; Minimal Luxury
- Design Profile; Glassmorphism SaaS

## Notes
Design profiles should define visual language, not page structure. Page structure belongs in archetype files.