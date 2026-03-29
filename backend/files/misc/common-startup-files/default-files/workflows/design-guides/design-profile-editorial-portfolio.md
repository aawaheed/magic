# Design Profile; Editorial Portfolio
WORKFLOW ==> design-profile-editorial-portfolio

## Summary
A high-contrast, art-directed visual system using bold typography, grid discipline, dramatic cropping, and strong storytelling hierarchy.

## Best use cases
- personal portfolios
- creative studios
- agencies
- magazines
- storytelling sites

## Visual identity
- Mood: artistic, intelligent, expressive
- Tone: confident, curated, refined
- Density: medium-low
- Contrast: high

## Typography
- Heading font: Archivo
- Body font: Inter
- Monospace font: IBM Plex Mono
- H1 size: clamp(3.5rem, 7vw, 7rem)
- H2 size: clamp(2.2rem, 3vw, 3.5rem)
- Body size: 17px
- Line height: 1.7
- Letter spacing: -0.03em for headings

## Color system
- Background: #F3F0EA
- Background secondary: #EAE4DB
- Surface: #FFFFFF
- Surface elevated: #FCFAF7
- Text primary: #111111
- Text secondary: #57524B
- Accent primary: #BF4C2C
- Accent secondary: #1C1C1C
- Border: rgba(17,17,17,0.10)
- Glow: rgba(191,76,44,0.08)
- Shadow: rgba(0,0,0,0.08)

## Spacing and layout
- Max content width: 1280px
- Section padding: 104px 28px
- Card padding: 26px
- Grid gap: 24px
- Border radius: 12px
- Border width: 1px

## Components
### Buttons
- Primary button: dark editorial button with crisp edge
- Secondary button: text button or outlined button
- Hover: underline or slight offset
- Radius: 999px or 10px depending on context
- Padding: 13px 20px

### Cards
- Background: paper-like light surface
- Border: subtle crisp border
- Shadow: barely visible
- Blur: none
- Radius: 12px

### Forms
- Input background: #FFFFFF
- Input border: rgba(17,17,17,0.12)
- Input text: #111111
- Input radius: 12px
- Focus state: darker border and subtle accent underline feel

### Navigation
- Height: 80px
- Background: mostly transparent
- Border: optional thin divider
- Link style: editorial text links
- CTA style: compact dark button

## Motion
- Transition speed: 180ms
- Easing: cubic-bezier(0.2, 0.8, 0.2, 1)
- Hover effects: reveal, shift, underline, image zoom
- Scroll effects: sectional reveal and image parallax
- Glow animation: no
- Parallax: yes, subtle on imagery

## Imagery direction
- Photography: art-directed, high quality, dramatic crop
- Illustration: selective and graphic
- 3D: rarely needed
- Backgrounds: paper texture, muted tone, editorial image fields
- Icons: minimal or absent

## Do
- Let typography dominate
- Use strong visual rhythm
- Embrace asymmetry carefully
- Crop images with intention
- Create clear section hierarchy

## Avoid
- too many flashy UI effects
- generic startup gradients
- over-rounded components
- cluttered iconography
- weak typography

## Hero direction
Use a large editorial headline, offset supporting copy, and one dominant visual with strong composition.

## Implementation notes
The typography and grid do most of the work. Keep UI minimal so the content direction feels authored and premium.

## Tokens
```json
{
  "fonts": {
    "heading": "Archivo",
    "body": "Inter",
    "mono": "IBM Plex Mono"
  },
  "colors": {
    "bg": "#F3F0EA",
    "bg2": "#EAE4DB",
    "surface": "#FFFFFF",
    "surface2": "#FCFAF7",
    "text": "#111111",
    "muted": "#57524B",
    "accent": "#BF4C2C",
    "accent2": "#1C1C1C",
    "border": "rgba(17,17,17,0.10)",
    "glow": "rgba(191,76,44,0.08)",
    "shadow": "rgba(0,0,0,0.08)"
  },
  "layout": {
    "maxWidth": "1280px",
    "sectionPadding": "104px 28px",
    "cardPadding": "26px",
    "gap": "24px",
    "radius": "12px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "180ms",
    "easing": "cubic-bezier(0.2, 0.8, 0.2, 1)"
  }
}
```