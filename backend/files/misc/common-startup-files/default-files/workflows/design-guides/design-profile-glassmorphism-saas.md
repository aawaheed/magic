# Design Profile; Glassmorphism SaaS
WORKFLOW ==> design-profile-glassmorphism-saas

## Summary
A polished layered interface with translucent cards, soft blur, gentle gradients, and startup-friendly clarity.

## Best use cases
- startup landing pages
- app homepages
- onboarding flows
- waitlists
- AI and SaaS products

## Visual identity
- Mood: polished, fresh, optimistic
- Tone: modern, accessible, clean
- Density: medium
- Contrast: medium-high

## Typography
- Heading font: Sora
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(3rem, 5.4vw, 5rem)
- H2 size: clamp(2rem, 3vw, 3rem)
- Body size: 16px
- Line height: 1.65
- Letter spacing: -0.02em for headings

## Color system
- Background: #0B1020
- Background secondary: #121933
- Surface: rgba(255,255,255,0.10)
- Surface elevated: rgba(255,255,255,0.14)
- Text primary: #F7FAFF
- Text secondary: #B7C0D4
- Accent primary: #6F8CFF
- Accent secondary: #89F1E1
- Border: rgba(255,255,255,0.18)
- Glow: rgba(111,140,255,0.24)
- Shadow: rgba(4,8,18,0.42)

## Spacing and layout
- Max content width: 1200px
- Section padding: 96px 24px
- Card padding: 24px
- Grid gap: 24px
- Border radius: 24px
- Border width: 1px

## Components
### Buttons
- Primary button: filled cool accent with soft shine
- Secondary button: glass button with border
- Hover: lift, brighter border, mild glow
- Radius: 999px
- Padding: 14px 22px

### Cards
- Background: frosted glass surface
- Border: bright alpha border
- Shadow: soft floating shadow
- Blur: 14px to 20px
- Radius: 24px

### Forms
- Input background: rgba(255,255,255,0.09)
- Input border: rgba(255,255,255,0.16)
- Input text: #F7FAFF
- Input radius: 16px
- Focus state: stronger border and subtle accent glow

### Navigation
- Height: 76px
- Background: semi-transparent glass
- Border: subtle glass edge
- Link style: clean and neutral
- CTA style: bright accent pill

## Motion
- Transition speed: 220ms
- Easing: cubic-bezier(0.22, 1, 0.36, 1)
- Hover effects: lift, blur shimmer, border emphasis
- Scroll effects: fade, slight upward reveal
- Glow animation: very subtle ambient pulse
- Parallax: yes, light

## Imagery direction
- Photography: product-focused and modern
- Illustration: soft gradients and abstract scenes
- 3D: acceptable if subtle
- Backgrounds: layered gradients and blurred lights
- Icons: rounded and clean

## Do
- Layer surfaces carefully
- Use glass only on important blocks
- Keep text readable with strong contrast
- Use 1 main accent and 1 support accent
- Keep blur elegant and consistent

## Avoid
- Too many glass layers
- weak contrast on text
- random colors
- overuse of glow
- noisy backgrounds behind content

## Hero direction
Use a large bright headline, glass CTA cluster, and product mockup framed by layered gradient lights.

## Implementation notes
Glass needs contrast, clear hierarchy, and clean spacing to avoid looking muddy. Use blur on cards, not everywhere.

## Tokens
```json
{
  "fonts": {
    "heading": "Sora",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#0B1020",
    "bg2": "#121933",
    "surface": "rgba(255,255,255,0.10)",
    "surface2": "rgba(255,255,255,0.14)",
    "text": "#F7FAFF",
    "muted": "#B7C0D4",
    "accent": "#6F8CFF",
    "accent2": "#89F1E1",
    "border": "rgba(255,255,255,0.18)",
    "glow": "rgba(111,140,255,0.24)",
    "shadow": "rgba(4,8,18,0.42)"
  },
  "layout": {
    "maxWidth": "1200px",
    "sectionPadding": "96px 24px",
    "cardPadding": "24px",
    "gap": "24px",
    "radius": "24px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "220ms",
    "easing": "cubic-bezier(0.22, 1, 0.36, 1)"
  }
}
```