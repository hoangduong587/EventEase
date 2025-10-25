# EventEase Security Configuration

## HTTPS Configuration

This application is configured to run with HTTPS in development and production.

### Development HTTPS Setup

1. **Certificate Installation**: A development certificate has been installed and trusted
2. **Launch Profile**: HTTPS is now the default launch profile
3. **Port Configuration**: 
   - HTTPS: `https://localhost:7188`
   - HTTP: `http://localhost:5063` (fallback)

### Security Headers

The application includes the following security headers:

- **X-Content-Type-Options**: `nosniff`
- **X-Frame-Options**: `DENY`
- **X-XSS-Protection**: `1; mode=block`
- **Referrer-Policy**: `strict-origin-when-cross-origin`
- **Permissions-Policy**: `attribution-reporting=()` (disables Attribution Reporting API)
- **Content-Security-Policy**: Restrictive policy for enhanced security

### Attribution Reporting API

The Attribution Reporting API warning has been resolved by:

1. **Running on HTTPS**: The application now defaults to HTTPS
2. **Permissions Policy**: Explicitly disabled attribution reporting
3. **Security Headers**: Added proper security configurations

### Running the Application

To run with HTTPS (recommended):
```bash
dotnet run --launch-profile https
```

To run with HTTP only (not recommended for production):
```bash
dotnet run --launch-profile http
```

### Production Deployment

For production deployment:

1. **Use HTTPS**: Always serve over HTTPS in production
2. **Certificate**: Use a valid SSL certificate from a trusted CA
3. **Security Headers**: The web.config includes production-ready security headers
4. **CSP Policy**: Review and adjust Content Security Policy as needed

### Browser Compatibility

The security configuration is compatible with:
- Chrome/Edge 80+
- Firefox 75+
- Safari 13+

### Troubleshooting

If you see Attribution Reporting API warnings:
1. Ensure you're accessing the app via HTTPS
2. Check that the development certificate is trusted
3. Verify the Permissions-Policy header is being sent

### Additional Security Considerations

- The CSP policy allows `unsafe-inline` and `unsafe-eval` for Blazor compatibility
- Font and image sources allow data: URIs and HTTPS resources
- WebSocket connections are allowed for Blazor SignalR support
- Frame ancestors are denied to prevent clickjacking