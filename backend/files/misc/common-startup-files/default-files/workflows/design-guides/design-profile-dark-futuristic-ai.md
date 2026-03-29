# Design Profile; Dark Futuristic AI
WORKFLOW ==> design-profile-dark-futuristic-ai

## Summary
A premium dark interface with restrained glow, translucent surfaces, elegant depth, and a futuristic AI-product feel.

## Best use cases
- AI startups
- SaaS landing pages
- product demos
- dashboards
- developer tools

## Visual identity
- Mood: futuristic, intelligent, cinematic
- Tone: premium, focused, high-tech
- Density: medium
- Contrast: high

## Typography
- Heading font: Space Grotesk
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(3rem, 6vw, 5.5rem)
- H2 size: clamp(2rem, 3vw, 3rem)
- Body size: 16px
- Line height: 1.6
- Letter spacing: -0.02em for headings

## Color system
- Background: #070B14
- Background secondary: #0D1320
- Surface: rgba(255,255,255,0.06)
- Surface elevated: rgba(255,255,255,0.10)
- Text primary: #F5F7FB
- Text secondary: #AAB3C5
- Accent primary: #7C5CFF
- Accent secondary: #4DE2C5
- Border: rgba(255,255,255,0.12)
- Glow: rgba(124,92,255,0.35)
- Shadow: rgba(0,0,0,0.38)

## Spacing and layout
- Max content width: 1200px
- Section padding: 96px 24px
- Card padding: 24px
- Grid gap: 24px
- Border radius: 20px
- Border width: 1px

## Components
### Buttons
- Primary button: solid accent with soft glow
- Secondary button: translucent dark surface with border
- Hover: slight lift and brighter glow
- Radius: 999px
- Padding: 14px 22px

### Cards
- Background: translucent dark glass
- Border: soft white alpha border
- Shadow: large soft shadow
- Blur: 12px to 18px
- Radius: 20px

### Forms
- Input background: rgba(255,255,255,0.05)
- Input border: rgba(255,255,255,0.10)
- Input text: #F5F7FB
- Input radius: 14px
- Focus state: accent glow and brighter border

### Navigation
- Height: 76px
- Background: transparent to light glass on scroll
- Border: subtle bottom border
- Link style: muted until hover
- CTA style: rounded filled accent button

## Motion
- Transition speed: 220ms
- Easing: cubic-bezier(0.22, 1, 0.36, 1)
- Hover effects: slight raise, glow increase
- Scroll effects: subtle fade and translate
- Glow animation: very subtle pulse only
- Parallax: yes, restrained

## Imagery direction
- Photography: high contrast, dark, atmospheric
- Illustration: sleek geometric or neural motifs
- 3D: subtle, premium, not playful
- Backgrounds: dark gradients, space, depth haze
- Icons: thin, clean, modern

## Do
- Use large bold headlines
- Keep spacing generous
- Use glow sparingly
- Prefer 1 to 2 accent colors
- Make cards feel layered and premium

## Avoid
- Neon overload
- Excessively bright backgrounds
- Harsh drop shadows
- Too many gradients in one viewport
- Cartoon styling unless user asks

## Hero direction
Use a bold headline with short supporting copy, a clear CTA, and either a 3D focal scene or a bento product preview with subtle background motion.

## Implementation notes
Prefer dark radial backgrounds, glass cards, soft borders, restrained violet or cyan glow, and low-noise motion. Keep everything crisp and spacious.

## Tokens
```json
{
  "fonts": {
    "heading": "Space Grotesk",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#070B14",
    "bg2": "#0D1320",
    "surface": "rgba(255,255,255,0.06)",
    "surface2": "rgba(255,255,255,0.10)",
    "text": "#F5F7FB",
    "muted": "#AAB3C5",
    "accent": "#7C5CFF",
    "accent2": "#4DE2C5",
    "border": "rgba(255,255,255,0.12)",
    "glow": "rgba(124,92,255,0.35)",
    "shadow": "rgba(0,0,0,0.38)"
  },
  "layout": {
    "maxWidth": "1200px",
    "sectionPadding": "96px 24px",
    "cardPadding": "24px",
    "gap": "24px",
    "radius": "20px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "220ms",
    "easing": "cubic-bezier(0.22, 1, 0.36, 1)"
  }
}
```