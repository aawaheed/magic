# Design Profile; Neo Brutalist Product
WORKFLOW ==> neo-brutalist-product

## Summary
A bold, high-personality design system using heavy borders, flat surfaces, oversized typography, raw contrast, and intentional anti-polish. It feels independent, modern, and expressive while still being usable for product marketing and brand-led interfaces.

## Best use cases
- indie SaaS
- creator tools
- startup landing pages
- agency websites
- portfolio products
- community platforms

## Visual identity
- Mood: bold, rebellious, energetic
- Tone: direct, playful, confident
- Density: medium
- Contrast: very high

## Typography
- Heading font: Space Grotesk
- Body font: Inter
- Monospace font: IBM Plex Mono
- H1 size: clamp(3.4rem, 7vw, 6.2rem)
- H2 size: clamp(2.2rem, 3.5vw, 3.6rem)
- Body size: 17px
- Line height: 1.6
- Letter spacing: -0.03em for headings

## Color system
- Background: #FFF9E8
- Background secondary: #FDEFD1
- Surface: #FFFFFF
- Surface elevated: #FFF2B8
- Text primary: #111111
- Text secondary: #2D2D2D
- Accent primary: #FF5C39
- Accent secondary: #245BFF
- Border: #111111
- Glow: rgba(255,92,57,0.0)
- Shadow: rgba(17,17,17,1)

## Spacing and layout
- Max content width: 1220px
- Section padding: 88px 24px
- Card padding: 24px
- Grid gap: 22px
- Border radius: 8px
- Border width: 3px

## Components
### Buttons
- Primary button: solid accent block with thick border
- Secondary button: white block with black border
- Hover: hard offset shadow movement
- Radius: 8px
- Padding: 14px 20px

### Cards
- Background: flat white or flat accent panel
- Border: thick black outline
- Shadow: hard offset shadow
- Blur: none
- Radius: 8px

### Forms
- Input background: #FFFFFF
- Input border: #111111
- Input text: #111111
- Input radius: 8px
- Focus state: strong outline or fill shift

### Navigation
- Height: 78px
- Background: solid background field
- Border: thick bottom border
- Link style: bold text links
- CTA style: blocky outlined or filled button

## Motion
- Transition speed: 120ms
- Easing: linear
- Hover effects: hard translate and hard shadow switch
- Scroll effects: reveal only if subtle
- Glow animation: none
- Parallax: no

## Imagery direction
- Photography: cutout, direct, personality-led
- Illustration: graphic, comic-like, geometric
- 3D: optional but stylized
- Backgrounds: flat color fields, stickers, shapes
- Icons: chunky, outlined, simple

## Do
- Use thick borders consistently
- Let typography be loud
- Embrace flat color blocks
- Keep layouts punchy and clear
- Use asymmetry with control

## Avoid
- soft glass effects
- luxury polish
- subtle invisible borders
- weak typography
- muddy color palettes

## Hero direction
Use a giant statement headline, a very obvious CTA, and a product preview framed like a poster or sticker board with hard-edged composition.

## Implementation notes
This profile depends on consistency. If the borders, spacing, and typography are not bold enough, the effect collapses into generic startup design.

## Tokens
```json
{
  "fonts": {
    "heading": "Space Grotesk",
    "body": "Inter",
    "mono": "IBM Plex Mono"
  },
  "colors": {
    "bg": "#FFF9E8",
    "bg2": "#FDEFD1",
    "surface": "#FFFFFF",
    "surface2": "#FFF2B8",
    "text": "#111111",
    "muted": "#2D2D2D",
    "accent": "#FF5C39",
    "accent2": "#245BFF",
    "border": "#111111",
    "glow": "rgba(255,92,57,0.0)",
    "shadow": "rgba(17,17,17,1)"
  },
  "layout": {
    "maxWidth": "1220px",
    "sectionPadding": "88px 24px",
    "cardPadding": "24px",
    "gap": "22px",
    "radius": "8px",
    "borderWidth": "3px"
  },
  "motion": {
    "duration": "120ms",
    "easing": "linear"
  }
}
```