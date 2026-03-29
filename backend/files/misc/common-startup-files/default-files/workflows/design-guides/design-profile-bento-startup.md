# Design Profile; Bento Startup
WORKFLOW ==> design-profile-bento-startup

## Summary
A modern startup style centered on modular content blocks, crisp hierarchy, compact storytelling, and product clarity.

## Best use cases
- product marketing pages
- AI tools
- mobile app launches
- startup homepages
- feature-rich landing pages

## Visual identity
- Mood: clear, energetic, modern
- Tone: pragmatic, confident, friendly
- Density: medium
- Contrast: high

## Typography
- Heading font: Manrope
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(2.8rem, 5vw, 4.8rem)
- H2 size: clamp(1.9rem, 2.8vw, 2.8rem)
- Body size: 16px
- Line height: 1.6
- Letter spacing: -0.025em for headings

## Color system
- Background: #0E1117
- Background secondary: #151A24
- Surface: #151B28
- Surface elevated: #1B2232
- Text primary: #F5F7FB
- Text secondary: #AAB3C2
- Accent primary: #8F7CFF
- Accent secondary: #25D0A5
- Border: rgba(255,255,255,0.10)
- Glow: rgba(143,124,255,0.18)
- Shadow: rgba(0,0,0,0.28)

## Spacing and layout
- Max content width: 1180px
- Section padding: 88px 24px
- Card padding: 22px
- Grid gap: 20px
- Border radius: 22px
- Border width: 1px

## Components
### Buttons
- Primary button: solid accent with strong contrast
- Secondary button: dark card button with border
- Hover: slight lift and shade shift
- Radius: 14px
- Padding: 13px 20px

### Cards
- Background: elevated dark surface
- Border: subtle alpha border
- Shadow: compact soft shadow
- Blur: none by default
- Radius: 22px

### Forms
- Input background: #141A26
- Input border: rgba(255,255,255,0.10)
- Input text: #F5F7FB
- Input radius: 14px
- Focus state: brighter border and mild accent glow

### Navigation
- Height: 74px
- Background: mostly transparent or solid on scroll
- Border: subtle divider
- Link style: practical and clean
- CTA style: medium rounded solid button

## Motion
- Transition speed: 180ms
- Easing: cubic-bezier(0.2, 0.8, 0.2, 1)
- Hover effects: small raise and shadow shift
- Scroll effects: quick reveal and fade
- Glow animation: no pulse by default
- Parallax: optional and light

## Imagery direction
- Photography: modern team/product images
- Illustration: simple geometric support art
- 3D: optional in hero only
- Backgrounds: gradients or subtle grid textures
- Icons: rounded modern UI icons

## Do
- Organize sections in easy-to-scan cards
- Keep copy concise
- Use metrics and proof blocks
- Balance feature and benefit messaging
- Maintain strong spacing rhythm

## Avoid
- giant text walls
- excessive ornamentation
- too many accent colors
- shallow contrast
- chaotic card sizing

## Hero direction
Use a strong left-aligned headline with a right-side product preview or bento block showing key value points and proof.

## Implementation notes
This style wins on clarity. Use modular cards, compact headlines, strong CTAs, and visually grouped information.

## Tokens
```json
{
  "fonts": {
    "heading": "Manrope",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#0E1117",
    "bg2": "#151A24",
    "surface": "#151B28",
    "surface2": "#1B2232",
    "text": "#F5F7FB",
    "muted": "#AAB3C2",
    "accent": "#8F7CFF",
    "accent2": "#25D0A5",
    "border": "rgba(255,255,255,0.10)",
    "glow": "rgba(143,124,255,0.18)",
    "shadow": "rgba(0,0,0,0.28)"
  },
  "layout": {
    "maxWidth": "1180px",
    "sectionPadding": "88px 24px",
    "cardPadding": "22px",
    "gap": "20px",
    "radius": "22px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "180ms",
    "easing": "cubic-bezier(0.2, 0.8, 0.2, 1)"
  }
}
```