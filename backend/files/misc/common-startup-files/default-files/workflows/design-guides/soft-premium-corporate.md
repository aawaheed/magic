# Design Profile; Soft Premium Corporate
WORKFLOW ==> soft-premium-corporate

## Summary
A calm, polished B2B design language built around trust, clarity, restraint, and soft premium visual cues. It avoids cold enterprise genericness by combining warm-neutral surfaces, subtle gradients, elegant spacing, and precise typography.

## Best use cases
- enterprise SaaS
- fintech
- healthtech
- legal tech
- cybersecurity
- consulting firms
- compliance products

## Visual identity
- Mood: calm, credible, polished
- Tone: trustworthy, mature, refined
- Density: medium
- Contrast: medium-high

## Typography
- Heading font: Plus Jakarta Sans
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(3rem, 5vw, 5rem)
- H2 size: clamp(2rem, 3vw, 3rem)
- Body size: 16px
- Line height: 1.65
- Letter spacing: -0.02em for headings

## Color system
- Background: #F7F8FC
- Background secondary: #EEF1F7
- Surface: rgba(255,255,255,0.82)
- Surface elevated: #FFFFFF
- Text primary: #172033
- Text secondary: #5E6A82
- Accent primary: #4A67FF
- Accent secondary: #7FD6C2
- Border: rgba(23,32,51,0.10)
- Glow: rgba(74,103,255,0.12)
- Shadow: rgba(15,23,42,0.08)

## Spacing and layout
- Max content width: 1240px
- Section padding: 96px 28px
- Card padding: 26px
- Grid gap: 24px
- Border radius: 18px
- Border width: 1px

## Components
### Buttons
- Primary button: solid indigo button with subtle depth
- Secondary button: soft white surface with border
- Hover: small lift and stronger shadow
- Radius: 999px
- Padding: 14px 22px

### Cards
- Background: frosted light surface
- Border: low-contrast cool border
- Shadow: soft layered shadow
- Blur: 8px to 12px
- Radius: 18px

### Forms
- Input background: rgba(255,255,255,0.9)
- Input border: rgba(23,32,51,0.12)
- Input text: #172033
- Input radius: 14px
- Focus state: indigo outline with soft glow

### Navigation
- Height: 76px
- Background: translucent light surface
- Border: subtle bottom border
- Link style: quiet text links with strong hover clarity
- CTA style: rounded premium button

## Motion
- Transition speed: 180ms
- Easing: cubic-bezier(0.22, 1, 0.36, 1)
- Hover effects: slight raise, opacity polish, soft glow
- Scroll effects: fade and upward reveal
- Glow animation: none by default
- Parallax: minimal

## Imagery direction
- Photography: professional, diverse, well-lit, human-centered
- Illustration: abstract geometric or data-inspired shapes
- 3D: minimal and restrained
- Backgrounds: soft gradients, blurred lights, premium neutral fields
- Icons: clean, thin, enterprise-friendly

## Do
- Prioritize readability and trust
- Use whitespace to signal confidence
- Keep surfaces soft and premium
- Use accent color sparingly
- Support strong information hierarchy

## Avoid
- overly futuristic visuals
- loud gradients
- crowded card layouts
- low-contrast text
- excessive motion

## Hero direction
Use a calm headline, clear business outcome, one trust-building proof element, and a polished product or dashboard preview with subtle premium depth.

## Implementation notes
Use neutral light backgrounds, gentle radius, controlled shadow, and concise messaging. This profile should feel executive-ready and conversion-oriented.

## Tokens
```json
{
  "fonts": {
    "heading": "Plus Jakarta Sans",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#F7F8FC",
    "bg2": "#EEF1F7",
    "surface": "rgba(255,255,255,0.82)",
    "surface2": "#FFFFFF",
    "text": "#172033",
    "muted": "#5E6A82",
    "accent": "#4A67FF",
    "accent2": "#7FD6C2",
    "border": "rgba(23,32,51,0.10)",
    "glow": "rgba(74,103,255,0.12)",
    "shadow": "rgba(15,23,42,0.08)"
  },
  "layout": {
    "maxWidth": "1240px",
    "sectionPadding": "96px 28px",
    "cardPadding": "26px",
    "gap": "24px",
    "radius": "18px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "180ms",
    "easing": "cubic-bezier(0.22, 1, 0.36, 1)"
  }
}
```