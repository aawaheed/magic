# Design Profile; Clean Developer System
WORKFLOW ==> clean-developer-system

## Summary
A precise, modular profile for developer-facing products that need to feel technical, modern, and highly usable. It supports documentation, APIs, code samples, terminal motifs, and product UIs without sacrificing polish.

## Best use cases
- API platforms
- developer tools
- cloud infrastructure
- observability products
- documentation sites
- open source products
- engineering dashboards

## Visual identity
- Mood: technical, precise, focused
- Tone: modern, competent, systematic
- Density: medium
- Contrast: high

## Typography
- Heading font: Inter
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(2.8rem, 5vw, 4.6rem)
- H2 size: clamp(1.9rem, 3vw, 2.8rem)
- Body size: 15px
- Line height: 1.65
- Letter spacing: -0.02em for headings

## Color system
- Background: #0B1020
- Background secondary: #11182B
- Surface: #121A2E
- Surface elevated: #18233D
- Text primary: #ECF3FF
- Text secondary: #9FB0CA
- Accent primary: #63A4FF
- Accent secondary: #7EF0C7
- Border: rgba(255,255,255,0.10)
- Glow: rgba(99,164,255,0.16)
- Shadow: rgba(0,0,0,0.26)

## Spacing and layout
- Max content width: 1280px
- Section padding: 88px 24px
- Card padding: 22px
- Grid gap: 20px
- Border radius: 16px
- Border width: 1px

## Components
### Buttons
- Primary button: compact technical accent button
- Secondary button: dark border button
- Hover: brighter accent and tiny lift
- Radius: 12px
- Padding: 12px 18px

### Cards
- Background: dark code-like panel
- Border: subtle system border
- Shadow: minimal depth
- Blur: none
- Radius: 16px

### Forms
- Input background: #0F172A
- Input border: rgba(255,255,255,0.12)
- Input text: #ECF3FF
- Input radius: 12px
- Focus state: blue ring and brighter border

### Navigation
- Height: 72px
- Background: stable dark shell
- Border: clean divider lines
- Link style: compact technical nav
- CTA style: utility-first action button

## Motion
- Transition speed: 160ms
- Easing: cubic-bezier(0.2, 0.8, 0.2, 1)
- Hover effects: color sharpen and subtle raise
- Scroll effects: light reveal only
- Glow animation: optional subtle cursor or panel glow
- Parallax: no

## Imagery direction
- Photography: rarely needed
- Illustration: system diagrams, nodes, code abstractions
- 3D: limited, abstract infrastructure forms
- Backgrounds: grids, terminals, subtle code motifs
- Icons: thin technical icons and file-type symbols

## Do
- Support code blocks as first-class elements
- Keep hierarchy explicit
- Use monospace strategically
- Make docs and UI feel unified
- Favor clear structure over visual flair

## Avoid
- generic marketing fluff
- excessive gradients
- low-contrast code samples
- decorative clutter
- playful consumer styling

## Hero direction
Use a strong technical promise, code or product preview, one clear CTA, and support content that proves capability fast.

## Implementation notes
Ensure terminals, code blocks, tabs, and docs navigation all inherit from the same spacing and border system. This profile should feel like a serious product for builders.

## Tokens
```json
{
  "fonts": {
    "heading": "Inter",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#0B1020",
    "bg2": "#11182B",
    "surface": "#121A2E",
    "surface2": "#18233D",
    "text": "#ECF3FF",
    "muted": "#9FB0CA",
    "accent": "#63A4FF",
    "accent2": "#7EF0C7",
    "border": "rgba(255,255,255,0.10)",
    "glow": "rgba(99,164,255,0.16)",
    "shadow": "rgba(0,0,0,0.26)"
  },
  "layout": {
    "maxWidth": "1280px",
    "sectionPadding": "88px 24px",
    "cardPadding": "22px",
    "gap": "20px",
    "radius": "16px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "160ms",
    "easing": "cubic-bezier(0.2, 0.8, 0.2, 1)"
  }
}
```