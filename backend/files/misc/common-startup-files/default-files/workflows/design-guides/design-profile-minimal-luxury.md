# Design Profile; Minimal Luxury
WORKFLOW ==> design-profile-minimal-luxury

## Summary
A refined, high-confidence design language built on whitespace, elegant typography, restrained color, and premium proportions.

## Best use cases
- luxury brands
- real estate
- premium consulting
- boutique agencies
- fashion and beauty

## Visual identity
- Mood: calm, sophisticated, elevated
- Tone: premium, mature, understated
- Density: low
- Contrast: medium-high

## Typography
- Heading font: Cormorant Garamond
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(3.2rem, 6vw, 6rem)
- H2 size: clamp(2.1rem, 3vw, 3.4rem)
- Body size: 17px
- Line height: 1.7
- Letter spacing: -0.015em for headings

## Color system
- Background: #F7F3EE
- Background secondary: #EFE7DE
- Surface: rgba(255,255,255,0.78)
- Surface elevated: #FFFFFF
- Text primary: #181512
- Text secondary: #6A625B
- Accent primary: #8B6B45
- Accent secondary: #B89A6A
- Border: rgba(24,21,18,0.10)
- Glow: rgba(184,154,106,0.18)
- Shadow: rgba(36,24,14,0.10)

## Spacing and layout
- Max content width: 1240px
- Section padding: 112px 28px
- Card padding: 28px
- Grid gap: 28px
- Border radius: 18px
- Border width: 1px

## Components
### Buttons
- Primary button: dark text on warm gold accent
- Secondary button: transparent with refined border
- Hover: slight darkening and lift
- Radius: 999px
- Padding: 14px 24px

### Cards
- Background: light matte surface
- Border: subtle warm border
- Shadow: soft low-contrast shadow
- Blur: none or very slight
- Radius: 18px

### Forms
- Input background: rgba(255,255,255,0.86)
- Input border: rgba(24,21,18,0.12)
- Input text: #181512
- Input radius: 14px
- Focus state: warmer border and soft highlight

### Navigation
- Height: 80px
- Background: transparent or light matte
- Border: subtle bottom divider
- Link style: understated text links
- CTA style: warm rounded premium button

## Motion
- Transition speed: 200ms
- Easing: cubic-bezier(0.25, 1, 0.5, 1)
- Hover effects: subtle lift and opacity shift
- Scroll effects: fade and reveal only
- Glow animation: none by default
- Parallax: minimal

## Imagery direction
- Photography: editorial, warm, natural light
- Illustration: minimal line art if any
- 3D: very limited
- Backgrounds: texture, soft gradients, premium photography
- Icons: thin and elegant

## Do
- Use whitespace generously
- Pair serif headlines with clean body text
- Keep palette restrained
- Use high-quality photography
- Let hierarchy carry the design

## Avoid
- Bright saturated colors
- heavy glow
- overly playful motion
- too many boxed sections
- cluttered interfaces

## Hero direction
Use a spacious editorial hero with strong serif typography, one high-quality image, and a concise CTA cluster.

## Implementation notes
Use fewer elements, larger margins, softer borders, and premium type scale. Prioritize elegance over density.

## Tokens
```json
{
  "fonts": {
    "heading": "Cormorant Garamond",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#F7F3EE",
    "bg2": "#EFE7DE",
    "surface": "rgba(255,255,255,0.78)",
    "surface2": "#FFFFFF",
    "text": "#181512",
    "muted": "#6A625B",
    "accent": "#8B6B45",
    "accent2": "#B89A6A",
    "border": "rgba(24,21,18,0.10)",
    "glow": "rgba(184,154,106,0.18)",
    "shadow": "rgba(36,24,14,0.10)"
  },
  "layout": {
    "maxWidth": "1240px",
    "sectionPadding": "112px 28px",
    "cardPadding": "28px",
    "gap": "28px",
    "radius": "18px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "200ms",
    "easing": "cubic-bezier(0.25, 1, 0.5, 1)"
  }
}
```